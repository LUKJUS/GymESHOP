-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 27, 2024 at 01:50 PM
-- Server version: 8.0.34
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eshop`
--

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `Id` int NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Price` double DEFAULT NULL,
  `Img` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`Id`, `Name`, `Type`, `Price`, `Img`, `Description`) VALUES
(1, 'Yamamoto Nutrition ISO-FUJI CFM išrūgų baltymų izoliatas', 'Protein', 37.99, 'iso-fuji', ' Maisto papildas, kurio pagrindą sudaro išrūgų baltymai, naudojant kryžminio srauto ultrafiltracija ir mikrofiltracija Volactive® Ultra Whey XP kas užtikrina kokybę. Papildas tinka sportininkams, kurie užsiima sunkia ir intensyvi fizine veikla.\r\n\r\nMikrofiltracija yra pats brangiausias baltymų papildų, kurių pagrindas yra išrūgų baltymai, išskyrimas, tačiau jis taip pat yra geriausias būdas išsaugoti vientisumą ir biologiškai aktyvių baltymų frakcijų buvimą, nuo kurių priklauso baltymo kokybė.\r\n\r\nVartojimas: porciją 30g išmaišykite su 80ml vandens, gerkite kartą per dieną tarp valgių arba po treniruotės.');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
