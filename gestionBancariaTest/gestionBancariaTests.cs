﻿using System;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gestionBancariaApp;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
        [TestMethod]
          
        // unit test code [TestMethod]
        public void ValidarIngreso_Valido()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 500;
            double saldoActual = 0;
            double saldoEsperado = 1500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);
            // Método a probar
            cuenta.realizarIngreso(ingreso);
            // afirmación de la prueba (valor esperado Vs. Valor obtenido)
            saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarIngreso_Invalido()
        {
            // Arrange
            double saldoInicial = 1000;
            double ingreso = -500;


            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(ingreso);

            double saldoObtenido = cuenta.obtenerSaldo();

            Assert.AreEqual(saldoInicial, saldoObtenido, "El saldo debe mantenerse igual después de un ingreso inválido.");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ValidarIngreso_Letras()
        {
            double saldoInicial = 1000;
            string ingreso = "aaaa";

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(Double.Parse(ingreso));

            Assert.ThrowsException<FormatException>(() => cuenta.realizarIngreso(Double.Parse(ingreso)));

            double saldoObtenido = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoInicial, saldoObtenido, "El saldo debe mantenerse igual después de un ingreso inválido.");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidarIngreso_Null()
        {
            // Arrange
           
            double saldoInicial = 1000;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(double.Parse(null));

            Assert.ThrowsException<ArgumentNullException>(() => cuenta.realizarIngreso(double.Parse(null)));

        }      

        [TestMethod]
        public void ValidarReintegro_Valido()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 500;
            double saldoActual = 0;
            double saldoEsperado = 500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);
           
            cuenta.realizarReintegro(reintegro);

            saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidarReintegro_Invalido()
        {
            // Arrange
            double saldoInicial = 1000;
            double reintegro = -500;


            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            cuenta.realizarIngreso(reintegro);

            double saldoObtenido = cuenta.obtenerSaldo();

            Assert.AreEqual(saldoInicial, saldoObtenido, "El saldo debe mantenerse igual después de un ingreso inválido.");

        }
    }


}
