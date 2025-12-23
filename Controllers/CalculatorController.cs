using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services;
using Confluent.Kafka;
using System.Text.Json;

namespace WebApplication2.Controllers
{
	public enum Operation { Add, Subtract, Multiply, Divide }

	public class CalculatorController : Controller
    {
        private CalculatorContext _context;
		private readonly KafkaProducerService<Null, string> _producer;

		public CalculatorController(CalculatorContext context, KafkaProducerService<Null, string> producer)
        {
            _context = context;
			_producer = producer;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(double num1, double num2, Models.Operation operation)
        {
            double result = 0;

            switch (operation)
            {
                case Models.Operation.Add:
                    result = num1 + num2;
                    break;
                case Models.Operation.Subtract:
                    result = num1 - num2;
                    break;
                case Models.Operation.Multiply:
                    result = num1 * num2;
                    break;
                case Models.Operation.Divide:
                    if (num2 == 0)
                    {
                        ViewBag.Error = "Деление на ноль невозможно!";
                        return View("Index");
                    }
                    result = num1 / num2;
                    break;
            }
            ViewBag.Num1 = num1;
            ViewBag.Num2 = num2;
            ViewBag.operation = operation;
            ViewBag.Result = result;

            // Подготовка объекта для расчета
            var dataInputVariant = new DataInputVarian
            {
                Num1 = num1,
                Num2 = num2,
                operation = operation,
                Result = result.ToString()
            };


            // Отправка данных в Kafka
            await SendDataToKafka(dataInputVariant);

            // Перенаправление на страницу Index
            // await Task.Delay(5000);
            return View("Index");
            // return RedirectToAction(nameof(Index));
        }
        public IActionResult Callback([FromBody] DataInputVarian inputData)
        {
            // Сохранение данных и результата в базе данных
            SaveDataAndResult(inputData);
            return Ok();
        }
        private DataInputVarian SaveDataAndResult(DataInputVarian inputData)
        {
            _context.DataInputVarians.Add(inputData);
            _context.SaveChanges();
            return inputData;
        }
        private async Task SendDataToKafka(DataInputVarian dataInputVariant)
        {
            var json = JsonSerializer.Serialize(dataInputVariant);
            await _producer.ProduceAsync("2_Calculator", new Message<Null, string> { Value = json });
        }
    }

}
