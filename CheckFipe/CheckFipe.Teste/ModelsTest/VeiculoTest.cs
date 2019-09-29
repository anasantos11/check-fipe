﻿using CheckFipe.Enums;
using CheckFipe.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckFipe.Teste.ModelsTest
{
    public class VeiculoTest
    {
        [TestCase(TipoVeiculoFipe.Carros, 21, 4828, "2013-1", "001267-0", "Fiat", "Palio 1.0 ECONOMY Fire Flex 8V 4p", "2013", "Gasolina")]
        [TestCase(TipoVeiculoFipe.Motos, 101, 3060, "1995-1", "827001-5", "YAMAHA", "750 VIRAGO", "1995", "Gasolina" )]
        [TestCase(TipoVeiculoFipe.Caminhoes, 109, 3302, "1997-3", "509001-6", "MERCEDES-BENZ", "1114 3-Eixos 2p (diesel)", "1997", "Diesel")]
        public void ValidarCarregamentoDosAnos(TipoVeiculoFipe tipoVeiculo, long codigoMarca, long codigoModelo, string codigoAno, string codigoFipeEsperado, string marcaEsperada, string modeloEsperado, string anoEsperado, string combustivelEsperado)
        {
            Veiculo veiculoBuscado = Veiculo.Carregar(tipoVeiculo, codigoMarca, codigoModelo, codigoAno);

            Assert.IsNotNull(veiculoBuscado);
            Assert.AreEqual(codigoMarca, veiculoBuscado.Marca.Codigo);
            Assert.AreEqual(marcaEsperada, veiculoBuscado.Marca.Nome);
            Assert.AreEqual(codigoModelo, veiculoBuscado.Modelo.Codigo);
            Assert.AreEqual(modeloEsperado, veiculoBuscado.Modelo.Nome);
            Assert.AreEqual(codigoAno, veiculoBuscado.Ano.Codigo);
            Assert.AreEqual(codigoFipeEsperado, veiculoBuscado.CodigoFipe);
            Assert.AreEqual(anoEsperado, veiculoBuscado.AnoModelo);
            Assert.AreEqual(combustivelEsperado, veiculoBuscado.DescricaoCombustivel);
            Assert.IsNotNull(veiculoBuscado.MesReferencia);
            Assert.IsNotNull(veiculoBuscado.Preco);
        }
    }
}
