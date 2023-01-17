-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.27-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para expenses
CREATE DATABASE IF NOT EXISTS `expenses` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_spanish_ci */;
USE `expenses`;

-- Volcando estructura para tabla expenses.apart
CREATE TABLE IF NOT EXISTS `apart` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ExpenseId` int(11) NOT NULL,
  `Amount` decimal(7,2) NOT NULL,
  `DateRegistration` date NOT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `IsApartN` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla expenses.apart: ~38 rows (aproximadamente)
INSERT INTO `apart` (`Id`, `ExpenseId`, `Amount`, `DateRegistration`, `IsActive`, `IsApartN`) VALUES
	(1, 27, 360.00, '2022-12-27', 1, 0),
	(2, 28, 263.00, '2022-12-27', 1, 0),
	(3, 39, 300.00, '2022-12-27', 1, 0),
	(4, 41, 100.00, '2022-12-27', 1, 0),
	(5, 42, 100.00, '2022-12-27', 1, 0),
	(6, 43, 100.00, '2022-12-27', 1, 0),
	(7, 44, 100.00, '2022-12-27', 1, 0),
	(8, 45, 100.00, '2020-12-27', 1, 0),
	(9, 46, 400.00, '2020-12-27', 1, 0),
	(10, 47, 200.00, '2020-12-27', 1, 0),
	(11, 48, 100.00, '2020-12-27', 1, 0),
	(12, 56, 800.00, '2022-12-27', 1, 0),
	(13, 57, 1700.00, '2022-12-27', 1, 0),
	(14, 58, 1500.00, '2022-12-27', 1, 0),
	(15, 59, 1900.00, '2022-12-27', 1, 0),
	(16, 66, -500.00, '2022-12-29', 1, 0),
	(17, 72, -923.00, '2023-01-09', 1, 0),
	(18, 74, 175.00, '2023-01-09', 1, 0),
	(19, 75, 100.00, '2023-01-09', 1, 0),
	(20, 81, 100.00, '2023-01-10', 1, 0),
	(21, 82, 100.00, '2023-01-10', 1, 0),
	(22, 83, 100.00, '2023-01-10', 1, 0),
	(23, 84, 100.00, '2023-01-10', 1, 0),
	(24, 85, 100.00, '2023-01-10', 1, 0),
	(25, 86, 200.00, '2023-01-10', 1, 0),
	(26, 88, -175.00, '2023-01-10', 1, 0),
	(27, 90, 100.00, '2023-01-10', 1, 0),
	(28, 91, 100.00, '2023-01-10', 1, 0),
	(29, 92, 300.00, '2023-01-10', 1, 0),
	(30, 93, 300.00, '2023-01-10', 1, 0),
	(31, 95, 500.00, '2023-01-10', 1, 0),
	(32, 96, 105.00, '2023-01-10', 1, 0),
	(33, 98, 2094.35, '2023-01-10', 0, 0),
	(34, 99, 3207.89, '2023-01-10', 0, 0),
	(35, 100, -200.00, '2023-01-10', 1, 0),
	(36, 101, 400.00, '2023-01-10', 1, 0),
	(37, 102, 300.00, '2023-01-10', 1, 0),
	(39, 107, 125.00, '2023-01-16', 1, 1);

-- Volcando estructura para tabla expenses.buy
CREATE TABLE IF NOT EXISTS `buy` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) NOT NULL,
  `MonthsWhithoutInterest` int(11) NOT NULL,
  `Amount` decimal(7,2) NOT NULL,
  `DateRegistration` date NOT NULL,
  `DatePay` date DEFAULT NULL,
  `BuyIdPay` int(11) NOT NULL DEFAULT 0,
  `IsActive` int(11) NOT NULL DEFAULT 1,
  `TdcId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_buy_tdc` (`TdcId`)
) ENGINE=MyISAM AUTO_INCREMENT=33 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla expenses.buy: 32 rows
/*!40000 ALTER TABLE `buy` DISABLE KEYS */;
INSERT INTO `buy` (`Id`, `Name`, `MonthsWhithoutInterest`, `Amount`, `DateRegistration`, `DatePay`, `BuyIdPay`, `IsActive`, `TdcId`) VALUES
	(1, 'Ajuste', 0, -1812.41, '2022-12-27', NULL, 0, 1, 1),
	(2, 'Intereses del periodo', 0, 250.88, '2022-01-04', NULL, 0, 1, 1),
	(3, 'Silla nancy', 15, 5100.00, '2022-02-04', NULL, 0, 1, 1),
	(4, 'Tablet', 12, 3804.00, '2022-07-09', NULL, 0, 1, 1),
	(5, 'Pc', 6, 11082.00, '2022-07-09', NULL, 0, 1, 1),
	(6, 'Horno electrico', 9, 1701.00, '2022-09-13', NULL, 0, 1, 1),
	(7, 'Ajuste', 0, -2554.41, '2023-01-04', NULL, 0, 1, 1),
	(8, 'Pago de MSI', 0, -2554.41, '2023-01-04', NULL, 0, 1, 1),
	(9, 'Pago ingles', 0, 2650.00, '2023-01-04', NULL, 0, 1, 1),
	(10, 'Microsoft', 0, 1441.24, '2023-01-04', NULL, 0, 1, 1),
	(11, 'Cepillo Nancy', 0, 899.10, '2022-11-24', NULL, 0, 1, 1),
	(12, 'Telmex', 0, 349.00, '2023-01-04', NULL, 0, 1, 1),
	(13, 'Pago parcial ingles', 0, -900.00, '2023-01-04', NULL, 0, 1, 1),
	(14, 'Pago de meses sin interes', 0, -2693.00, '2023-01-04', NULL, 0, 1, 1),
	(15, 'Anualidad', 0, 2410.00, '2023-01-04', NULL, 0, 1, 1),
	(16, 'Microsoft', 0, 2104.00, '2023-01-04', NULL, 0, 1, 1),
	(17, 'Pago parcial ingles', 0, -900.00, '2023-01-04', NULL, 0, 1, 1),
	(18, 'Pago parcial ingles', 0, -900.00, '2023-01-04', NULL, 0, 1, 1),
	(19, 'Microsoft devoluciÃ³n', 0, -615.38, '2023-01-04', NULL, 0, 1, 1),
	(20, 'Microsoft devoluciÃ³n', 0, -1441.24, '2023-01-04', NULL, 0, 1, 1),
	(21, 'Microsoft devoluciÃ³n', 0, -1489.34, '2023-01-04', NULL, 0, 1, 1),
	(22, 'Alimento gatos', 0, 599.00, '2023-01-04', NULL, 0, 1, 1),
	(23, 'Pago alimento gatos', 0, 600.00, '2023-01-04', NULL, 0, 1, 1),
	(24, 'Intereses del periodo', 0, 279.00, '2023-01-04', NULL, 0, 1, 1),
	(25, 'Pago cepillo nancy', 0, -900.00, '2023-01-09', NULL, 11, 1, 1),
	(26, 'Pago pc', 0, -1850.00, '2023-01-09', NULL, 5, 1, 1),
	(27, 'Pago MSI', 0, -850.00, '2023-01-10', NULL, 0, 1, 1),
	(28, 'hamburguesas', 0, 350.00, '2023-01-10', NULL, 0, 1, 1),
	(29, 'Bici', 0, 12104.00, '2023-01-15', NULL, 0, 1, 1),
	(30, 'Pizza', 0, 250.00, '2023-01-15', NULL, 0, 1, 1),
	(31, 'PAgo', 0, -6200.00, '2023-01-15', NULL, 29, 1, 1),
	(32, 'Pago', 0, -250.00, '2023-01-16', NULL, 30, 1, 1);
/*!40000 ALTER TABLE `buy` ENABLE KEYS */;

-- Volcando estructura para tabla expenses.category
CREATE TABLE IF NOT EXISTS `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) NOT NULL,
  `IsActive` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla expenses.category: ~4 rows (aproximadamente)
INSERT INTO `category` (`Id`, `Name`, `IsActive`) VALUES
	(1, 'Gastos', 1),
	(2, 'Ingresos', 1),
	(3, 'Apartado', 1),
	(4, 'Plan', 1),
	(5, 'Para borrar', 0);

-- Volcando estructura para tabla expenses.expense
CREATE TABLE IF NOT EXISTS `expense` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `SubcategoryId` int(11) NOT NULL,
  `Amount` decimal(7,2) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `PeriodId` int(11) DEFAULT NULL,
  `DateRegistration` date DEFAULT NULL,
  `Guid` tinytext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla expenses.expense: ~98 rows (aproximadamente)
INSERT INTO `expense` (`Id`, `Name`, `SubcategoryId`, `Amount`, `IsActive`, `PeriodId`, `DateRegistration`, `Guid`) VALUES
	(1, 'Salario', 1, 12000.00, 1, 1, NULL, NULL),
	(2, 'Nancy', 1, 2500.00, 1, 1, NULL, NULL),
	(7, 'Aguinaldo', 1, 12711.00, 1, 7, NULL, NULL),
	(8, 'Plan Afore Tecreo', 11, 2600.00, 1, 7, NULL, NULL),
	(9, 'Internet', 45, 448.00, 1, 7, NULL, NULL),
	(10, 'Gatos Alimento', 26, 600.00, 1, 10, NULL, NULL),
	(11, 'Salida y pizza', 49, 600.00, 1, 11, NULL, NULL),
	(12, 'Salario', 1, 12107.69, 1, 8, NULL, NULL),
	(13, 'Saldo', 40, 90.00, 1, 8, NULL, NULL),
	(15, 'Doña', 22, 1500.00, 1, 8, NULL, NULL),
	(16, 'Afore->Techreo', 11, 700.00, 1, 8, NULL, NULL),
	(17, 'Ingles', 23, 900.00, 1, 1, NULL, NULL),
	(18, 'Doña', 22, 1500.00, 1, 1, NULL, NULL),
	(19, 'Tianguis', 17, 500.00, 1, 1, NULL, NULL),
	(20, 'Pollo', 49, 200.00, 1, 1, NULL, NULL),
	(21, 'Renta', 2, 3000.00, 1, 1, NULL, NULL),
	(22, 'Internet', 36, 200.00, 1, 1, NULL, NULL),
	(23, 'Gas', 38, 250.00, 1, 1, NULL, NULL),
	(24, 'semana', 28, 600.00, 1, 1, NULL, NULL),
	(25, 'semana', 29, 600.00, 1, 1, NULL, NULL),
	(26, 'efectivo', 42, 210.00, 1, 1, NULL, NULL),
	(27, 'Techero->Compu', 16, 360.00, 1, 1, NULL, NULL),
	(28, 'Compu', 16, 263.00, 1, 1, NULL, NULL),
	(29, 'seguro', 31, 300.00, 1, 1, NULL, NULL),
	(30, '', 33, 90.00, 1, 1, NULL, NULL),
	(31, 'Refri', 22, 500.00, 1, 1, NULL, NULL),
	(32, 'Lentes', 48, 1300.00, 1, 1, NULL, NULL),
	(33, '', 40, 70.00, 1, 1, NULL, NULL),
	(34, '', 11, 1000.00, 1, 1, NULL, NULL),
	(35, '', 35, 290.00, 1, 1, NULL, NULL),
	(36, '', 18, 700.00, 1, 1, NULL, NULL),
	(37, 'Gastos varios', 42, 1000.00, 1, 1, NULL, NULL),
	(38, 'Navidad', 49, 3000.00, 1, 7, NULL, NULL),
	(39, 'Compu', 16, 300.00, 1, 8, NULL, NULL),
	(40, 'Sabatico techreo 347', 9, 300.00, 1, 8, NULL, NULL),
	(41, '', 6, 100.00, 1, 8, NULL, NULL),
	(42, '', 12, 100.00, 1, 8, NULL, NULL),
	(43, '', 43, 100.00, 1, 8, NULL, NULL),
	(44, '', 14, 100.00, 1, 8, NULL, NULL),
	(45, '', 15, 100.00, 1, 8, NULL, NULL),
	(46, '', 13, 400.00, 1, 8, NULL, NULL),
	(47, '', 16, 200.00, 1, 8, NULL, NULL),
	(48, 'Anualidad Tdc', 16, 100.00, 1, 8, '2022-12-26', NULL),
	(49, 'Navida', 48, 500.00, 1, 7, NULL, NULL),
	(50, 'Rosca de reyes', 49, 400.00, 1, 7, NULL, NULL),
	(56, 'Ajuste', 6, 800.00, 1, 0, NULL, NULL),
	(57, '', 12, 1700.00, 1, 0, NULL, NULL),
	(58, '', 14, 1500.00, 1, 0, NULL, NULL),
	(59, '', 15, 1900.00, 1, 0, NULL, NULL),
	(60, '', 2, 2800.00, 1, 8, NULL, NULL),
	(61, '', 28, 600.00, 1, 8, NULL, NULL),
	(62, '', 42, 400.00, 0, 8, NULL, NULL),
	(63, '', 42, 1100.00, 1, 8, NULL, NULL),
	(64, 'Techero 3601', 42, 2563.00, 1, 7, NULL, NULL),
	(65, '', 38, 250.00, 1, 8, NULL, NULL),
	(66, 'Calzones', 14, -500.00, 1, 9, NULL, NULL),
	(67, 'año nuevo', 49, 2000.00, 1, 7, NULL, NULL),
	(68, 'Reyes de las creaturas', 42, 600.00, 1, 7, NULL, NULL),
	(69, '', 3, 1000.00, 1, 8, NULL, NULL),
	(70, '', 29, 600.00, 1, 8, NULL, NULL),
	(71, '', 18, 1000.00, 1, 8, NULL, NULL),
	(72, 'Retiro para pago de compu', 16, -923.00, 1, 9, NULL, NULL),
	(73, '', 17, 500.00, 1, 8, NULL, NULL),
	(74, 'Internet', 16, 175.00, 1, 8, NULL, NULL),
	(75, 'Luz CDMX', 16, 100.00, 1, 8, NULL, NULL),
	(76, '', 50, 1892.00, 1, 8, NULL, NULL),
	(77, '', 1, 12107.69, 1, 11, NULL, NULL),
	(78, 'Techero 90', 11, 700.00, 1, 11, NULL, NULL),
	(79, 'techero sabatico', 9, 300.00, 1, 11, NULL, NULL),
	(80, '', 22, 1500.00, 1, 11, NULL, NULL),
	(81, '', 6, 100.00, 1, 11, NULL, NULL),
	(82, '', 12, 100.00, 1, 11, NULL, NULL),
	(83, '', 43, 100.00, 1, 11, NULL, NULL),
	(84, '', 14, 100.00, 1, 11, NULL, NULL),
	(85, '', 15, 100.00, 1, 11, NULL, NULL),
	(86, '', 16, 200.00, 1, 11, NULL, NULL),
	(87, '', 34, 333.00, 1, 11, NULL, NULL),
	(88, 'Pago internet', 16, -175.00, 1, 9, NULL, NULL),
	(89, '', 45, 175.00, 1, 11, NULL, NULL),
	(90, 'Agua CDMX', 16, 100.00, 1, 11, NULL, NULL),
	(91, 'CDMX Luz', 16, 100.00, 1, 11, NULL, NULL),
	(92, 'Gatos Alimento', 16, 300.00, 1, 11, NULL, NULL),
	(93, 'Gatos arena', 16, 300.00, 1, 11, NULL, NULL),
	(94, '', 23, 850.00, 1, 11, NULL, NULL),
	(95, 'Ingles', 16, 500.00, 1, 11, NULL, NULL),
	(96, 'Anualidad tdc', 16, 105.00, 1, 11, NULL, NULL),
	(97, '', 27, 850.00, 1, 11, NULL, NULL),
	(98, '', 51, 0.00, 1, 11, NULL, NULL),
	(99, '', 52, 1689.35, 1, 11, NULL, NULL),
	(100, '', 13, -200.00, 1, 9, NULL, NULL),
	(101, 'Pago predial tlax', 13, 400.00, 1, 11, NULL, NULL),
	(102, 'Plan PC', 16, 300.00, 1, 11, NULL, NULL),
	(103, '', 28, 600.00, 1, 11, NULL, NULL),
	(104, '', 29, 600.00, 1, 11, NULL, NULL),
	(107, '', 34, 125.00, 1, 14, '2023-01-16', '(NULL)'),
	(108, '', 17, 500.00, 1, 11, '2023-01-16', NULL),
	(109, '', 3, 2500.00, 1, 11, '2023-01-16', NULL),
	(110, '', 2, 2800.00, 1, 11, '2023-01-16', NULL);

-- Volcando estructura para tabla expenses.investment
CREATE TABLE IF NOT EXISTS `investment` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `DateStart` date NOT NULL,
  `DateStop` date NOT NULL,
  `Interest` decimal(4,2) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `Amount` decimal(7,2) DEFAULT NULL,
  `InstructionId` int(11) DEFAULT NULL,
  `Term` int(11) DEFAULT NULL,
  `AmountFinal` decimal(4,2) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla expenses.investment: ~25 rows (aproximadamente)
INSERT INTO `investment` (`Id`, `Name`, `DateStart`, `DateStop`, `Interest`, `IsActive`, `Amount`, `InstructionId`, `Term`, `AmountFinal`) VALUES
	(2, 'Afore', '2022-12-29', '2022-12-01', 2.95, 1, 31493.58, 1, 28, NULL),
	(3, 'Afore 1377131690', '2022-11-28', '2022-12-28', 2.95, 1, 5086.08, 1, 28, NULL),
	(4, 'Otro', '2022-12-20', '2022-12-27', 2.90, 1, 10187.56, 1, 7, NULL),
	(5, 'In0991', '2022-12-20', '2022-12-27', 2.90, 1, 10314.61, 1, 7, NULL),
	(6, 'Afore 1377859279', '2022-12-20', '2027-12-27', 2.90, 1, 5049.84, 1, 7, NULL),
	(7, 'Afore 1377859279', '2022-12-20', '2022-12-27', 2.90, 1, 5038.95, 1, 7, NULL),
	(8, 'Seminario  137785940', '2022-12-15', '2022-12-22', 2.90, 1, 10187.26, 1, 7, NULL),
	(9, 'Seminario 1377859406', '2022-12-15', '2022-12-22', 2.90, 1, 2620.21, 1, 7, NULL),
	(10, 'Sabatico 1377860641', '2022-03-11', '2023-01-30', 3.00, 1, 26820.11, 1, 91, NULL),
	(11, 'Sabatico 1380097640', '2022-12-20', '2022-12-27', 2.90, 1, 5101.33, 1, 7, NULL),
	(12, 'Sabatico 1380097640', '2022-12-20', '2022-12-27', 2.90, 1, 10259.94, 1, 7, NULL),
	(13, 'Sabatico 1380097640', '2022-12-15', '2022-12-22', 2.90, 1, 2012.23, 1, 7, NULL),
	(14, 'Afore 28 1380169919', '2022-12-14', '2023-01-11', 2.95, 1, 10250.00, 1, 28, NULL),
	(15, 'Techreo 2471', '2022-11-23', '2022-12-23', 0.50, 0, 100.00, 1, 28, NULL),
	(16, 'Techreo 2492', '2022-11-28', '2022-12-28', 5.00, 0, 3000.00, 1, 1, NULL),
	(17, 'Techreo 2975', '2022-12-17', '2023-01-17', 0.50, 1, 2400.00, 1, 28, NULL),
	(18, 'Afore Techero', '2022-12-26', '2023-03-27', 6.50, 1, 700.00, 3, 90, NULL),
	(19, 'Sabatico techreo 347', '2022-12-26', '2023-06-26', 8.00, 1, 300.00, 3, 180, NULL),
	(20, 'Techreo 3598', '2022-12-29', '2023-01-30', 5.00, 1, 3015.01, 3, 28, NULL),
	(21, 'Techero 3600', '2022-12-29', '2023-01-30', 6.00, 1, 206.19, 3, 3, NULL),
	(22, 'Techero 3601', '2022-12-29', '2023-01-30', 6.00, 1, 2563.00, 3, 1, NULL),
	(23, 'techrero', '2023-01-10', '2023-02-10', 6.00, 1, 1200.00, 3, 30, NULL),
	(24, 'Afore techero', '2023-01-10', '2023-04-10', 6.50, 1, 700.00, 3, 90, NULL),
	(25, 'techero sabatico 3771', '2023-01-10', '2023-07-10', 10.00, 1, 300.00, 3, 30, NULL),
	(26, 'techero 3879', '2023-01-10', '2023-02-10', 6.00, 1, 1200.00, 3, 30, NULL),
	(27, 'techero resto bici 3964', '2023-01-16', '2023-02-16', 6.00, 1, 1800.00, 3, 28, NULL);

-- Volcando estructura para tabla expenses.period
CREATE TABLE IF NOT EXISTS `period` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) NOT NULL,
  `DateStart` date NOT NULL,
  `DateStop` date NOT NULL,
  `IsActive` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla expenses.period: ~8 rows (aproximadamente)
INSERT INTO `period` (`Id`, `Name`, `DateStart`, `DateStop`, `IsActive`) VALUES
	(1, 'Diciembre', '2022-12-23', '2022-12-10', 0),
	(6, 'Diciembre', '2022-12-23', '2023-01-10', 1),
	(7, 'Aguinaldo', '2022-12-16', '2022-12-16', 1),
	(8, 'Diciembre 23', '2022-12-23', '2023-01-10', 1),
	(9, 'Retiros de apartados', '2023-01-01', '2023-01-10', 0),
	(10, 'prueba', '2023-01-05', '2023-01-10', 0),
	(11, 'Enero 10', '2023-01-10', '2023-01-25', 1),
	(12, 'para borrar', '2023-01-12', '2023-01-12', 0),
	(13, 'Prueba para borrar', '2023-01-13', '2023-01-20', 0),
	(14, 'Prueba', '2023-01-14', '2023-01-25', 1);

-- Volcando estructura para tabla expenses.subcategory
CREATE TABLE IF NOT EXISTS `subcategory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryId` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `IsActive` int(11) NOT NULL,
  `Amount` decimal(8,2) NOT NULL,
  `TypeId` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`Id`),
  KEY `FK_subcategory_category` (`CategoryId`),
  CONSTRAINT `FK_subcategory_category` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla expenses.subcategory: ~45 rows (aproximadamente)
INSERT INTO `subcategory` (`Id`, `CategoryId`, `Name`, `IsActive`, `Amount`, `TypeId`) VALUES
	(1, 2, 'A Salario', 1, -12100.00, 1),
	(2, 1, 'Renta', 1, 2800.00, 1),
	(3, 2, 'A Nancy', 1, -2500.00, 1),
	(5, 3, 'Plan PC', 1, 300.00, 1),
	(6, 3, 'Ahorro Camioneta', 1, 100.00, 1),
	(9, 3, 'Plan sabatico', 1, 300.00, 1),
	(11, 3, 'Plan Afore', 1, 700.00, 1),
	(12, 3, 'Ahorro vacaciones', 1, 100.00, 1),
	(13, 3, 'Ahorro gastos Tlax', 1, 400.00, 1),
	(14, 3, 'Ahorro Ropa', 1, 100.00, 1),
	(15, 3, 'Ahorro gastos medicos', 1, 100.00, 1),
	(16, 3, 'Ahorro N', 1, 200.00, 1),
	(17, 1, 'Alimentación Tianguis s1', 1, 500.00, 1),
	(18, 1, 'Alimentación Comida Toña', 1, 1000.00, 1),
	(19, 1, 'Alimentación App', 1, 0.00, 1),
	(20, 1, 'Natacion', 1, 250.00, 1),
	(21, 1, 'Escuela de burritos', 0, 250.00, 1),
	(22, 1, 'Doña', 1, 1500.00, 1),
	(23, 1, 'Ingles', 1, 1350.00, 1),
	(24, 1, 'Entretenimiento', 1, 400.00, 1),
	(25, 1, 'Gatos Arena', 1, 300.00, 1),
	(26, 1, 'Gatos Alimento', 1, 300.00, 1),
	(27, 1, 'TDC', 1, 850.00, 1),
	(28, 1, 'Semana 1', 1, 550.00, 1),
	(29, 1, 'Semana 2', 1, 550.00, 1),
	(30, 1, 'TDC Anualidad', 1, 105.00, 1),
	(31, 1, 'Seguro doña', 1, 150.00, 1),
	(32, 1, 'Seguro Bbva', 1, 75.00, 1),
	(33, 1, 'Nesflis', 1, 90.00, 1),
	(34, 1, 'Tlax Luz', 1, 125.00, 1),
	(35, 1, 'CDMX Luz', 1, 100.00, 1),
	(36, 1, 'Tlax Internet ', 1, 100.00, 1),
	(38, 1, 'Gas', 1, 250.00, 1),
	(39, 1, 'Entretenimiento Crunchiroll', 0, 60.00, 1),
	(40, 1, 'Cel saldo', 1, 75.00, 1),
	(42, 1, 'x Efectivo', 1, 0.00, 1),
	(43, 3, 'Ahorro Libros Tec', 1, 100.00, 1),
	(45, 1, 'CDMX Internet', 1, 175.00, 1),
	(47, 1, 'CDMX Agua', 1, 100.00, 1),
	(48, 1, 'Mili', 1, 0.00, 1),
	(49, 1, 'Alimentacion', 1, 0.00, 1),
	(50, 1, 'Gastos varios', 1, 0.00, 1),
	(51, 1, 'Xuenta BBva', 1, 0.00, 1),
	(52, 1, 'Xuenta Techero', 1, 0.00, 1),
	(53, 2, 'string', 0, 10.00, 1),
	(54, 1, 'Alimentación Tianguis s2', 1, 500.00, 1);

-- Volcando estructura para tabla expenses.tdc
CREATE TABLE IF NOT EXISTS `tdc` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Bank` varchar(50) NOT NULL,
  `DayCut` int(11) NOT NULL,
  `DatePay` datetime NOT NULL,
  `Interest` decimal(5,2) NOT NULL,
  `IsActive` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- Volcando datos para la tabla expenses.tdc: 1 rows
/*!40000 ALTER TABLE `tdc` DISABLE KEYS */;
INSERT INTO `tdc` (`Id`, `Name`, `Bank`, `DayCut`, `DatePay`, `Interest`, `IsActive`) VALUES
	(1, 'Plata', 'Bancomer', 3, '2023-01-04 17:41:37', 56.00, 1);
/*!40000 ALTER TABLE `tdc` ENABLE KEYS */;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
