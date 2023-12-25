using lab3_App.Controllers;
using lab3_App.Models;
using lab3_App.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9___Test
{
    public class CarControllerTest
    {
        private CarController _controller;
        private ICarService _service;

        public CarControllerTest()
        {
            _service = new MemoryCarService();
            _service.Add(new Car() { Model = "Test1" });
            _service.Add(new Car() { Model = "Test2" });
            _controller = new CarController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<List<Car>>(view.Model);
            List<Car>? list = view.Model as List<Car>;
            Assert.NotNull(list);
            Assert.Equal(3, list.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingCars(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<Car>(view.Model);
            Car model = view.Model as Car;
            Assert.NotNull(model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTestForNonExistingCar()
        {
            var result = _controller.Details(9999);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateTest()
        {
            Car model = new Car { Model = "Test", ManufacturerId = 1001, EngineType = Engine.Hybrid, RegistratioinNumber = 1345 };
            var prevCount = _service.FindAll().Count;
            _controller.Create(model);
            Assert.Equal(prevCount + 1, _service.FindAll().Count);
        }

        [Fact]
        public void CreateInvalidCarTest()
        {
            Car model = new Car { Id = 1, Model = "Test" };
            var prevCount = _service.FindAll().Count;
            Assert.Throws<Exception>(() => _controller.Create(model));
            Assert.Equal(prevCount, _service.FindAll().Count);
        }

        [Fact]
        public void UpdateTest()
        {
            Car model = _service.FindById(1);
            int oldNumber = model.RegistratioinNumber;
            model.RegistratioinNumber = 2137;
            _controller.Update(model);
            Assert.NotEqual(_service.FindById(1).RegistratioinNumber, oldNumber);
        }

        [Fact]
        public void UpdateForNonExistingCarTest()
        {
            Car model = new Car { Id = 50 };
            model.RegistratioinNumber = 76543;
            var result = _controller.Update(model);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteTest()
        {
            Car model = _service.FindById(2);
            _controller.Delete(model);
            Assert.Equal(_service.FindById(2), null);
        }

        [Fact]
        public void DeleteNonExistantCarTest()
        {
            Car model = new Car { Id = 50 };
            var result = _controller.Delete(model);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
