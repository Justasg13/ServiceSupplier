using System;
using ServiceSupplier.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceSupplier.Repositories;
using ServiceSupplier.Controllers;

namespace ServiceSupplierTest
{
    [TestClass]
    public class UnitTest1
    {
        private ClientRepository _clientRepository  = new ClientRepository();
        private SupplierRepository _supplierRepository = new SupplierRepository();
        [TestMethod]
        public void Add_ClientRepository_ClientAdded()
        {
            // Arrange
            ClientEntity clientEntity = new ClientEntity();
            clientEntity.Id = 1;
            clientEntity.Name = "Pirma";
            clientEntity.IdCountry = 1;
            clientEntity.IsInEuropeanUnion = true;
            clientEntity.IsVATPayer = true;
            clientEntity.VATPercentage = 21;
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            _clientRepository.Add(clientEntity);

            // Assert
            
            Assert.AreEqual(_clientRepository.GetBy(1).Name,"Pirma");
            Assert.AreEqual(_clientRepository.GetBy(1).Id, 1);
            Assert.AreEqual(_clientRepository.GetBy(1).IdCountry, 1);
            Assert.AreEqual(_clientRepository.GetBy(1).IsInEuropeanUnion, true);
            Assert.AreEqual(_clientRepository.GetBy(1).IsVATPayer, true);
            Assert.AreEqual(_clientRepository.GetBy(1).VATPercentage, 21);
            Assert.AreEqual(_clientRepository.GetCount(), 1);
        }
        [TestMethod]
        public void Add_SupplierRepository_SupplierAdded()
        {
            // Arrange
            SupplierEntity supplierEntity = new SupplierEntity();
            supplierEntity.Id = 1;
            supplierEntity.Name = "Pirma";
            supplierEntity.IdCountry = 1;
            supplierEntity.IsInEuropeanUnion = true;
            supplierEntity.IsVATPayer = true;
            supplierEntity.VATPercentage = 21;
            SupplierEntity supplierEntity2 = new SupplierEntity();
            supplierEntity2.Id = 2;
            supplierEntity2.Name = "Antra";
            supplierEntity2.IdCountry = 1;
            supplierEntity2.IsInEuropeanUnion = true;
            supplierEntity2.IsVATPayer = false;
            supplierEntity2.VATPercentage = 21;
            SupplierEntity supplierEntity3 = new SupplierEntity();
            supplierEntity3.Id = 3;
            supplierEntity3.Name = "Trecia";
            supplierEntity3.IdCountry = 2;
            supplierEntity3.IsInEuropeanUnion = false;
            supplierEntity3.IsVATPayer = true;
            supplierEntity3.VATPercentage = 18;
            InvoiceController invoiceController = new InvoiceController(_clientRepository, _supplierRepository);

            // Act
            _supplierRepository.Add(supplierEntity);
            _supplierRepository.Add(supplierEntity2);
            _supplierRepository.Add(supplierEntity3);

            // Assert

            Assert.AreEqual(_supplierRepository.GetBy(1).Name, "Pirma");
            Assert.AreEqual(_supplierRepository.GetBy(2).IsVATPayer, false);
            Assert.AreEqual(_supplierRepository.GetBy(3).Name, "Trecia");
            Assert.AreEqual(_supplierRepository.GetBy(3).Id, 3);
            Assert.AreEqual(_supplierRepository.GetCount(), 3);
        }


    }
}
