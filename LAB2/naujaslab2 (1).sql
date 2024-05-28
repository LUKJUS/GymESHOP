-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 13, 2024 at 05:13 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `naujaslab2`
--

-- --------------------------------------------------------

--
-- Table structure for table `atsiliepimas`
--

CREATE TABLE `atsiliepimas` (
  `Komentaras` varchar(255) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci DEFAULT NULL,
  `Data` date DEFAULT NULL,
  `Vertinimas` int(11) DEFAULT NULL,
  `id_Atsiliepimas` int(11) NOT NULL,
  `fk_Klientasid_Klientas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `atsiliepimas`
--

INSERT INTO `atsiliepimas` (`Komentaras`, `Data`, `Vertinimas`, `id_Atsiliepimas`, `fk_Klientasid_Klientas`) VALUES
('convallis tortor risus', '2024-01-07', 1, 1, 1),
('ultrices enim lorem ipsum dolor sit amet consectetuer', '2024-05-27', 4, 2, 2),
('augue a suscipit', '2024-01-17', 4, 3, 3),
('aenean lectus pellentesque eget nunc donec', '2024-01-04', 1, 4, 4),
('viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum', '2023-10-13', 2, 5, 5),
('eget tincidunt eget tempus vel pede morbi porttitor', '2023-08-16', 2, 6, 6),
('non interdum in ante vestibulum', '2024-01-25', 5, 7, 7),
('habitasse platea dictumst maecenas ut massa quis', '2024-01-02', 4, 8, 8),
('ligula sit amet eleifend pede libero quis', '2024-07-30', 5, 9, 9),
('aliquam quis turpis eget elit sodales scelerisque mauris sit amet', '2024-07-21', 4, 10, 10),
('ut suscipit a feugiat et eros vestibulum', '2024-04-06', 3, 11, 11),
('aliquam lacus morbi quis tortor id nulla ultrices aliquet', '2023-11-07', 2, 12, 12),
('aliquet massa id lobortis convallis tortor risus dapibus augue vel', '2023-09-05', 1, 13, 13),
('eget massa tempor convallis nulla neque libero convallis', '2024-03-14', 1, 14, 14),
('turpis nec euismod', '2023-05-19', 1, 15, 15),
('auctor gravida sem praesent id', '2024-03-12', 3, 16, 16),
('vulputate ut ultrices vel', '2024-04-27', 2, 17, 17),
('augue vestibulum ante ipsum primis in faucibus orci', '2024-02-22', 2, 18, 18),
('nec nisi volutpat eleifend', '2024-08-04', 1, 19, 19),
('non lectus aliquam sit amet diam in', '2023-06-26', 3, 20, 20),
('integer ac leo pellentesque ultrices mattis odio donec vitae', '2024-08-01', 3, 21, 21),
('velit eu est congue elementum in hac habitasse platea dictumst', '2023-12-21', 4, 22, 22),
('molestie nibh in lectus pellentesque at nulla suspendisse potenti', '2023-07-10', 3, 23, 23),
('ut erat curabitur gravida', '2023-10-09', 4, 24, 24),
('rutrum rutrum neque aenean auctor gravida sem praesent id massa', '2024-02-11', 3, 25, 25),
('luctus et ultrices posuere cubilia', '2024-01-14', 2, 26, 26),
('curae donec pharetra magna vestibulum', '2023-07-22', 2, 27, 27),
('maecenas rhoncus aliquam lacus morbi quis tortor id nulla', '2023-12-06', 2, 28, 28),
('commodo vulputate justo in blandit ultrices enim', '2024-03-30', 1, 29, 29),
('mi in porttitor pede justo eu massa donec dapibus duis', '2024-05-20', 1, 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `atsiskaitymo_budas`
--

CREATE TABLE `atsiskaitymo_budas` (
  `id_Atsiskaitymo_budas` int(11) NOT NULL,
  `name` char(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `atsiskaitymo_budas`
--

INSERT INTO `atsiskaitymo_budas` (`id_Atsiskaitymo_budas`, `name`) VALUES
(1, 'Grynas'),
(2, 'Kortele'),
(3, 'Issimoketinai');

-- --------------------------------------------------------

--
-- Table structure for table `busena`
--

CREATE TABLE `busena` (
  `id_Busena` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `busena`
--

INSERT INTO `busena` (`id_Busena`, `name`) VALUES
(1, 'Patvirtinta'),
(2, 'Uzsakyta'),
(3, 'Nutraukta'),
(4, 'Uzbaigta');

-- --------------------------------------------------------

--
-- Table structure for table `garazas`
--

CREATE TABLE `garazas` (
  `Adresas` varchar(255) NOT NULL,
  `Automobiliu_kiekis` int(11) NOT NULL,
  `Garazo_numeris` int(11) NOT NULL,
  `id_Garazas` int(11) NOT NULL,
  `fk_Vairuotojasid_Vairuotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `garazas`
--

INSERT INTO `garazas` (`Adresas`, `Automobiliu_kiekis`, `Garazo_numeris`, `id_Garazas`, `fk_Vairuotojasid_Vairuotojas`) VALUES
('2604 Schmedeman Drive', 1, 1, 1, 1),
('97 Melby Terrace', 2, 2, 2, 2),
('5 Service Alley', 3, 3, 3, 3),
('1 Elka Circle', 4, 4, 4, 4),
('3 Haas Hill', 5, 5, 5, 5),
('24310 Basil Point', 6, 6, 6, 6),
('5662 Sutherland Street', 7, 7, 7, 7),
('7 Tennyson Plaza', 8, 8, 8, 8),
('23 1st Place', 9, 9, 9, 9),
('6 Ilene Street', 10, 10, 10, 10),
('928 Vahlen Point', 11, 11, 11, 11),
('66652 Waubesa Avenue', 12, 12, 12, 12),
('39014 Derek Crossing', 13, 13, 13, 13),
('61 Burning Wood Park', 14, 14, 14, 14),
('5 Brickson Park Way', 15, 15, 15, 15),
('2962 Pierstorff Hill', 16, 16, 16, 16),
('2 Utah Trail', 17, 17, 17, 17),
('530 Lunder Park', 18, 18, 18, 18),
('3308 Hudson Street', 19, 19, 19, 19),
('4 Melrose Avenue', 20, 20, 20, 20),
('45431 Evergreen Place', 21, 21, 21, 21),
('0872 Browning Junction', 22, 22, 22, 22),
('98196 Maple Lane', 23, 23, 23, 23),
('0879 Mesta Parkway', 24, 24, 24, 24),
('3133 Northwestern Drive', 25, 25, 25, 25),
('98793 Nancy Point', 26, 26, 26, 26),
('909 Arkansas Circle', 27, 27, 27, 27),
('4 Debs Pass', 28, 28, 28, 28),
('604 Del Sol Avenue', 29, 29, 29, 29),
('44735 Northport Parkway', 30, 30, 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `klientas`
--

CREATE TABLE `klientas` (
  `Vardas` varchar(255) NOT NULL,
  `Pavarde` varchar(255) NOT NULL,
  `Adresas` varchar(255) NOT NULL,
  `Telefono_numeris` int(11) NOT NULL,
  `id_Klientas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `klientas`
--

INSERT INTO `klientas` (`Vardas`, `Pavarde`, `Adresas`, `Telefono_numeris`, `id_Klientas`) VALUES
('Cornell', 'Haking', '377 Tennyson Roadsgfdsdfg', 21476, 1),
('Celestine', 'Lunny', '8428 Crest Line Point sdfsdfgssdfgfg', 2147483647, 2),
('Hollie', 'Hamlet', '2 Redwing Trail', 2147483647, 3),
('Krysta', 'Pastor', '426 Briar Crest Hill', 2147483647, 4),
('Gerry', 'Abramow', '11 Lakewood Park', 2147483647, 5),
('Ashlan', 'Fairlem', '80257 Oak Street', 2147483647, 6),
('Cosme', 'Wessel', '7304 Main Crossing', 2147483647, 7),
('Terza', 'Erskin', '13 Del Mar Place', 2147483647, 8),
('Leese', 'Pantling', '974 Waywood Court', 2147483647, 9),
('Sapphire', 'Tinkler', '27 Village Green Drive', 2147483647, 10),
('Jess', 'Hryniewicki', '51940 Forest Run Road', 2147483647, 11),
('Wylie', 'Vamplew', '46808 Parkside Hill', 2147483647, 12),
('Meriel', 'Skyppe', '0 Rockefeller Place', 2147483647, 13),
('Hedvige', 'Eccleshall', '867 Southridge Lane', 2147483647, 14),
('Joaquin', 'Danilyuk', '4 Esker Street', 1892489128, 15),
('Urbain', 'Murrow', '515 Colorado Park', 2147483647, 16),
('Tiphanie', 'Danilyuk', '97545 American Center', 2147483647, 17),
('Eran', 'Birrell', '88673 David Crossing', 2147483647, 18),
('Saw', 'Ungerecht', '149 Straubel Street', 2147483647, 19),
('Rube', 'Ricci', '9902 Lerdahl Parkway', 2147483647, 20),
('Koenraad', 'Borel', '4474 Hovde Crossing', 2147483647, 21),
('Chadd', 'Meade', '8094 Independence Street', 2147483647, 22),
('Augusto', 'Bramah', '7 Donald Hill', 2147483647, 23),
('Dita', 'Stearns', '859 Birchwood Plaza', 2147483647, 24),
('Batholomew', 'Pudge', '4 Atwood Alley', 2147483647, 25),
('Millicent', 'Wilder', '991 Sachtjen Crossing', 2147483647, 26),
('Wallace', 'Rings', '109 Esker Hill', 2147483647, 27),
('Ashlen', 'Goodbourn', '0 Becker Avenue', 2147483647, 28),
('Mandi', 'Raecroft', '1741 Westport Road', 1128194698, 29),
('Reggie', 'Fynn', '833 Riverside Point', 2147483647, 30),
('gsdfsdfg', 'sgdfsdfg', 'gsdsdfggsdf', 0, 32);

-- --------------------------------------------------------

--
-- Table structure for table `krovinys`
--

CREATE TABLE `krovinys` (
  `Miestas` varchar(255) NOT NULL,
  `Svoris` double NOT NULL,
  `Pristatymo_busena` int(11) NOT NULL,
  `id_Krovinys` int(11) NOT NULL,
  `fk_Marsrutasid_Marsrutas` int(11) NOT NULL,
  `fk_Transporto_priemoneid_Transporto_priemone` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `krovinys`
--

INSERT INTO `krovinys` (`Miestas`, `Svoris`, `Pristatymo_busena`, `id_Krovinys`, `fk_Marsrutasid_Marsrutas`, `fk_Transporto_priemoneid_Transporto_priemone`) VALUES
('odio donec vitae', 451, 2, 1, 1, 1),
('in', 1368, 3, 2, 2, 2),
('massa tempor convallis nulla', 1963, 1, 3, 3, 3),
('nulla', 890, 3, 4, 4, 4),
('pharetra magna', 1752, 2, 5, 5, 5),
('donec ut dolor morbi', 1410, 4, 6, 6, 6),
('quisque porta volutpat', 1408, 3, 7, 7, 7),
('curabitur convallis duis consequat', 1338, 3, 8, 8, 8),
('sit', 257, 4, 9, 9, 9),
('enim', 1955, 4, 10, 10, 10),
('sagittis dui vel', 264, 1, 11, 11, 11),
('ultrices erat tortor sollicitudin', 942, 4, 12, 12, 12),
('mauris vulputate elementum nullam', 1541, 1, 13, 13, 13),
('id ornare imperdiet', 402, 1, 14, 14, 14),
('duis', 671, 2, 15, 15, 15),
('justo in hac habitasse', 1642, 4, 16, 16, 16),
('felis sed', 958, 1, 17, 17, 17),
('luctus rutrum nulla tellus', 735, 2, 18, 18, 18),
('nascetur ridiculus mus vivamus', 1800, 1, 19, 19, 19),
('vulputate luctus cum', 929, 1, 20, 20, 20),
('donec ut mauris', 471, 4, 21, 21, 21),
('leo pellentesque ultrices', 1538, 3, 22, 22, 22),
('massa tempor', 1933, 2, 23, 23, 23),
('donec ut dolor morbi', 915, 4, 24, 24, 24),
('duis', 1589, 3, 25, 25, 25),
('at', 231, 2, 26, 26, 26),
('ipsum primis', 1468, 2, 27, 27, 27),
('integer aliquet massa', 1209, 2, 28, 28, 28),
('in leo maecenas pulvinar', 405, 3, 29, 29, 29),
('lobortis convallis', 743, 3, 30, 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `marsrutas`
--

CREATE TABLE `marsrutas` (
  `Pradine_vieta` varchar(255) NOT NULL,
  `Paskirties_vieta` varchar(255) NOT NULL,
  `Atstumas` double NOT NULL,
  `Trukme` double NOT NULL,
  `id_Marsrutas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `marsrutas`
--

INSERT INTO `marsrutas` (`Pradine_vieta`, `Paskirties_vieta`, `Atstumas`, `Trukme`, `id_Marsrutas`) VALUES
('8394 Claremont Trail', '0 Karstens Place', 301, 825, 1),
('0289 Acker Trail', '96 Fair Oaks Street', 720, 735, 2),
('3 Michigan Circle', '30 Dahle Avenue', 109, 517, 3),
('3 Merchant Court', '83 Hallows Parkway', 575, 962, 4),
('32060 Killdeer Way', '8 Farmco Hill', 345, 757, 5),
('1 Glendale Hill', '4 Kensington Center', 497, 368, 6),
('66 Ryan Way', '718 Kinsman Lane', 736, 148, 7),
('038 Sunfield Road', '11918 Kingsford Point', 186, 97, 8),
('90 Sunbrook Avenue', '04 Old Gate Crossing', 607, 677, 9),
('4 Hallows Plaza', '7 Sauthoff Court', 760, 634, 10),
('9 Talisman Pass', '38 Debs Hill', 760, 698, 11),
('4 Magdeline Road', '43 Ridgeview Parkway', 351, 993, 12),
('474 Transport Street', '37151 Blue Bill Park Street', 401, 559, 13),
('03192 Debs Place', '7150 Hermina Trail', 577, 960, 14),
('082 Waubesa Way', '568 Hintze Lane', 209, 558, 15),
('4 Independence Trail', '651 Mcbride Terrace', 637, 331, 16),
('8856 Bellgrove Street', '9 Karstens Park', 689, 841, 17),
('3676 Garrison Center', '07419 Sullivan Road', 173, 514, 18),
('8 Orin Avenue', '23581 East Lane', 225, 79, 19),
('80 Ryan Trail', '55 Barby Parkway', 429, 396, 20),
('9971 Red Cloud Road', '9391 Katie Terrace', 45, 11, 21),
('6327 Sommers Crossing', '90794 Anzinger Circle', 116, 285, 22),
('764 Homewood Trail', '3 Farragut Parkway', 804, 217, 23),
('37 3rd Circle', '41 Old Shore Center', 634, 159, 24),
('3 Bowman Terrace', '3 Manley Road', 96, 863, 25),
('5 Dwight Plaza', '13687 Homewood Street', 73, 606, 26),
('921 Kingsford Pass', '660 Dayton Point', 930, 871, 27),
('4486 Brentwood Junction', '26287 Bunting Place', 815, 37, 28),
('033 Clemons Place', '628 Iowa Place', 194, 319, 29),
('076 Ronald Regan Terrace', '3163 Dixon Street', 994, 422, 30);

-- --------------------------------------------------------

--
-- Table structure for table `mokejimas`
--

CREATE TABLE `mokejimas` (
  `data` date NOT NULL,
  `suma` double NOT NULL,
  `mokejimo_budas` varchar(255) NOT NULL,
  `id_Mokejimas` int(11) NOT NULL,
  `fk_Saskaitaid_Saskaita` int(11) NOT NULL,
  `fk_Klientasid_Klientas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `mokejimas`
--

INSERT INTO `mokejimas` (`data`, `suma`, `mokejimo_budas`, `id_Mokejimas`, `fk_Saskaitaid_Saskaita`, `fk_Klientasid_Klientas`) VALUES
('2024-01-24', 51794, '3', 1, 1, 1),
('2023-07-26', 65407, '3', 2, 2, 2),
('2023-10-27', 1698, '1', 3, 3, 3),
('2023-09-30', 54228, '3', 4, 4, 4),
('2023-07-15', 41996, '1', 5, 5, 5),
('2023-07-11', 9023, '2', 6, 6, 6),
('2023-06-05', 13492, '3', 7, 7, 7),
('2023-10-25', 70783, '1', 8, 8, 8),
('2023-06-11', 71627, '3', 9, 9, 9),
('2024-01-04', 80424, '1', 10, 10, 10),
('2023-09-22', 66946, '1', 11, 11, 11),
('2024-02-21', 18258, '1', 12, 12, 12),
('2023-06-10', 43270, '2', 13, 13, 13),
('2023-12-22', 42104, '1', 14, 14, 14),
('2023-07-28', 17436, '3', 15, 15, 15),
('2023-10-06', 19176, '3', 16, 16, 16),
('2023-07-09', 2167, '2', 17, 17, 17),
('2023-05-26', 10081, '2', 18, 18, 18),
('2023-12-07', 11089, '3', 19, 19, 19),
('2023-09-30', 41522, '1', 20, 20, 20),
('2024-01-27', 13766, '3', 21, 21, 21),
('2023-09-04', 58746, '1', 22, 22, 22),
('2023-11-05', 50814, '2', 23, 23, 23),
('2023-06-24', 59602, '1', 24, 24, 24),
('2023-06-24', 1911, '3', 25, 25, 25),
('2023-10-28', 67757, '2', 26, 26, 26),
('2023-10-18', 39796, '1', 27, 27, 27),
('2024-02-25', 91563, '3', 28, 28, 28),
('2023-10-04', 71728, '3', 29, 29, 29),
('2023-06-20', 12893, '3', 30, 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `saskaita`
--

CREATE TABLE `saskaita` (
  `data` date NOT NULL,
  `suma` double NOT NULL,
  `id_Saskaita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `saskaita`
--

INSERT INTO `saskaita` (`data`, `suma`, `id_Saskaita`) VALUES
('2023-08-15', 7660, 1),
('2023-05-10', 86020, 2),
('2023-08-14', 10401, 3),
('2023-03-07', 82966, 4),
('2024-01-24', 60009, 5),
('2023-10-13', 64026, 6),
('2023-11-17', 82616, 7),
('2023-11-30', 58805, 8),
('2023-12-02', 64382, 9),
('2023-11-18', 13980, 10),
('2023-06-25', 14962, 11),
('2023-05-17', 44552, 12),
('2023-10-09', 84805, 13),
('2023-05-06', 44773, 14),
('2023-07-25', 35638, 15),
('2023-07-12', 15938, 16),
('2024-02-07', 31569, 17),
('2023-10-28', 43444, 18),
('2023-12-02', 77927, 19),
('2024-02-29', 1014, 20),
('2023-10-28', 55269, 21),
('2023-12-23', 37404, 22),
('2023-10-10', 6837, 23),
('2023-11-03', 90090, 24),
('2023-04-13', 76973, 25),
('2023-09-16', 62665, 26),
('2023-03-16', 60156, 27),
('2023-10-10', 53670, 28),
('2023-06-01', 53387, 29),
('2023-12-03', 97955, 30);

-- --------------------------------------------------------

--
-- Table structure for table `sutarties_busena`
--

CREATE TABLE `sutarties_busena` (
  `id_Sutarties_busena` int(11) NOT NULL,
  `name` char(12) CHARACTER SET utf8 COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sutarties_busena`
--

INSERT INTO `sutarties_busena` (`id_Sutarties_busena`, `name`) VALUES
(1, 'Pasirasyta'),
(2, 'Nepasirasyta');

-- --------------------------------------------------------

--
-- Table structure for table `tarpine_eilute`
--

CREATE TABLE `tarpine_eilute` (
  `kiekis` int(11) DEFAULT NULL,
  `id_Tarpine_eilute` int(11) NOT NULL,
  `fk_Krovinysid_Krovinys` int(11) DEFAULT NULL,
  `fk_Uzsakymasid_Uzsakymas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tarpine_eilute`
--

INSERT INTO `tarpine_eilute` (`kiekis`, `id_Tarpine_eilute`, `fk_Krovinysid_Krovinys`, `fk_Uzsakymasid_Uzsakymas`) VALUES
(4, 1, 1, 1),
(85, 2, 2, 2),
(47, 5, 5, 5),
(38, 6, 6, 6),
(73, 7, 7, 7),
(31, 8, 8, 8),
(56, 9, 9, 9),
(24, 11, 11, 11),
(45, 15, 15, 15),
(71, 17, 17, 17),
(13, 19, 19, 19),
(48, 20, 20, 20),
(81, 21, 21, 21),
(82, 22, 22, 22),
(38, 23, 23, 23),
(68, 24, 24, 24),
(12, 25, 25, 25),
(36, 26, 26, 26),
(28, 27, 27, 27),
(49, 28, 28, 28),
(6, 29, 29, 29),
(78, 30, 30, 30),
(65, 51, 22, 77),
(3, 52, 23, 79),
(5, 54, 22, 80);

-- --------------------------------------------------------

--
-- Table structure for table `transporto_priemone`
--

CREATE TABLE `transporto_priemone` (
  `Gamintojas` varchar(255) NOT NULL,
  `Modelis` varchar(255) NOT NULL,
  `Metai` int(11) NOT NULL,
  `Busenos_komentaras` varchar(255) NOT NULL,
  `Technine_bukle` varchar(255) NOT NULL,
  `Radijas` tinyint(1) NOT NULL,
  `Vietu_skaicius` int(11) NOT NULL,
  `Registravimo_data` date NOT NULL,
  `id_Transporto_priemone` int(11) NOT NULL,
  `fk_Garazasid_Garazas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transporto_priemone`
--

INSERT INTO `transporto_priemone` (`Gamintojas`, `Modelis`, `Metai`, `Busenos_komentaras`, `Technine_bukle`, `Radijas`, `Vietu_skaicius`, `Registravimo_data`, `id_Transporto_priemone`, `fk_Garazasid_Garazas`) VALUES
('ridiculus mus vivamus', 'luctus ultricies eu', 2001, 'eleifend', 'justo morbi ut odio cras', 1, 188, '2023-09-18', 1, 1),
('pellentesque ultrices', 'justo aliquam quis turpis', 2023, 'nisl venenatis', 'amet', 0, 125, '2023-09-18', 2, 2),
('in hac habitasse', 'quisque ut', 1990, 'aliquam lacus', 'viverra', 0, 101, '2023-10-28', 3, 3),
('posuere', 'enim', 2017, 'eu nibh quisque id', 'integer non velit donec', 0, 41, '2023-09-17', 4, 4),
('congue vivamus metus', 'pretium quis', 1990, 'amet turpis elementum', 'id', 0, 21, '2023-07-13', 5, 5),
('nunc', 'etiam justo etiam pretium', 2002, 'eu massa donec dapibus', 'quis turpis eget elit', 0, 119, '2024-02-21', 6, 6),
('sed tincidunt eu felis fusce', 'metus', 2007, 'aliquam erat volutpat in congue', 'nulla tellus in sagittis', 0, 93, '2023-11-02', 7, 7),
('molestie lorem quisque', 'libero quis orci nullam', 2007, 'dapibus nulla suscipit ligula', 'ut nulla', 0, 121, '2023-10-06', 8, 8),
('pretium', 'ante nulla justo aliquam', 2002, 'quisque id justo sit', 'lectus aliquam sit amet diam', 1, 5, '2023-07-17', 9, 9),
('ac tellus semper', 'ac diam cras', 2022, 'at velit', 'mus etiam vel augue', 0, 161, '2023-12-15', 10, 10),
('dolor vel', 'lacinia', 2003, 'pretium quis lectus suspendisse potenti', 'ipsum primis in', 0, 182, '2024-01-05', 11, 11),
('bibendum morbi non', 'sapien', 2022, 'augue aliquam erat volutpat', 'vulputate', 1, 200, '2024-02-07', 12, 12),
('habitasse platea', 'tellus', 1994, 'ridiculus mus vivamus', 'nam nulla integer', 1, 184, '2024-01-16', 13, 13),
('nullam sit amet turpis elementum', 'mauris sit amet eros', 1992, 'nunc vestibulum', 'ut erat', 1, 97, '2024-01-28', 14, 14),
('mattis egestas', 'ullamcorper augue a', 2002, 'volutpat quam', 'curabitur at ipsum ac', 1, 96, '2023-11-04', 15, 15),
('luctus et ultrices posuere', 'elementum eu interdum eu', 1998, 'dolor quis odio consequat varius', 'risus semper porta', 0, 153, '2023-06-26', 16, 16),
('erat', 'dolor quis odio', 2002, 'sociis', 'ipsum primis', 1, 163, '2024-01-23', 17, 17),
('ut', 'viverra dapibus', 2024, 'proin at turpis a pede', 'justo eu massa donec dapibus', 1, 124, '2023-07-17', 18, 18),
('iaculis justo in hac habitasse', 'magna', 1990, 'tempor', 'quam sollicitudin vitae consectetuer', 1, 56, '2023-12-16', 19, 19),
('eros vestibulum ac est lacinia', 'mattis odio', 1996, 'nunc rhoncus dui vel sem', 'erat vestibulum sed magna at', 1, 111, '2023-12-14', 20, 20),
('faucibus orci luctus', 'luctus', 2010, 'lorem', 'consectetuer adipiscing elit proin interdum', 1, 94, '2023-09-01', 21, 21),
('justo', 'quam pharetra magna ac', 2005, 'ligula in', 'congue eget', 1, 122, '2023-11-05', 22, 22),
('pede morbi porttitor lorem', 'a libero nam dui', 2005, 'mus etiam vel augue', 'blandit ultrices', 1, 79, '2023-06-03', 23, 23),
('elit proin interdum mauris non', 'sodales scelerisque mauris', 2015, 'amet sapien dignissim vestibulum', 'sit amet sapien', 0, 114, '2023-04-25', 24, 24),
('justo pellentesque', 'tempus sit amet', 2000, 'consequat in consequat ut', 'tempus vivamus in', 0, 89, '2023-09-25', 25, 25),
('dictumst aliquam augue', 'in eleifend quam a', 2000, 'felis sed interdum venenatis turpis', 'in quis justo maecenas rhoncus', 1, 23, '2023-06-08', 26, 26),
('donec odio justo sollicitudin ut', 'tincidunt', 1996, 'molestie lorem', 'tincidunt lacus at velit', 0, 46, '2024-01-14', 27, 27),
('erat', 'ante', 2003, 'pellentesque ultrices mattis', 'eleifend pede', 0, 145, '2023-08-09', 28, 28),
('quam suspendisse potenti nullam porttitor', 'erat nulla tempus vivamus', 1990, 'interdum mauris ullamcorper purus sit', 'consequat metus sapien ut', 1, 14, '2023-09-13', 29, 29),
('pellentesque eget nunc donec', 'volutpat quam pede', 2009, 'rutrum', 'sollicitudin', 1, 76, '2023-05-16', 30, 30);

-- --------------------------------------------------------

--
-- Table structure for table `uzsakymas`
--

CREATE TABLE `uzsakymas` (
  `Data` date NOT NULL,
  `Uzsakymo_statusas` int(11) NOT NULL,
  `Sutartis` int(11) NOT NULL,
  `id_Uzsakymas` int(11) NOT NULL,
  `fk_Atsiliepimasid_Atsiliepimas` int(11) NOT NULL,
  `fk_Klientasid_Klientas` int(11) NOT NULL,
  `fk_Vairuotojasid_Vairuotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `uzsakymas`
--

INSERT INTO `uzsakymas` (`Data`, `Uzsakymo_statusas`, `Sutartis`, `id_Uzsakymas`, `fk_Atsiliepimasid_Atsiliepimas`, `fk_Klientasid_Klientas`, `fk_Vairuotojasid_Vairuotojas`) VALUES
('2023-07-18', 3, 1, 1, 1, 1, 1),
('2024-08-07', 2, 1, 2, 2, 2, 2),
('2023-12-10', 4, 1, 5, 5, 5, 5),
('2024-05-09', 1, 1, 6, 6, 6, 6),
('2023-06-10', 4, 2, 7, 7, 7, 7),
('2023-07-19', 2, 1, 8, 8, 8, 8),
('2023-04-07', 2, 1, 9, 9, 9, 9),
('2023-03-25', 1, 2, 11, 11, 11, 11),
('2023-06-29', 3, 2, 15, 15, 15, 15),
('2024-07-04', 1, 2, 17, 17, 17, 17),
('2023-05-01', 2, 1, 19, 19, 19, 19),
('2024-01-12', 1, 2, 20, 20, 20, 20),
('2023-06-30', 3, 2, 21, 21, 21, 21),
('2023-07-27', 3, 2, 22, 22, 22, 22),
('2023-07-05', 3, 2, 23, 23, 23, 23),
('2023-03-28', 3, 1, 24, 24, 24, 24),
('2023-04-01', 4, 1, 25, 25, 25, 25),
('2024-05-02', 1, 1, 26, 26, 26, 26),
('2024-07-03', 4, 1, 27, 27, 27, 27),
('2023-11-25', 1, 2, 28, 28, 28, 28),
('2023-12-05', 1, 1, 29, 29, 29, 29),
('2023-08-23', 4, 1, 30, 30, 30, 30),
('2024-05-01', 2, 1, 77, 13, 15, 4),
('2024-05-02', 2, 1, 79, 15, 16, 17),
('2024-05-31', 2, 1, 80, 9, 18, 17);

-- --------------------------------------------------------

--
-- Table structure for table `vairuotojas`
--

CREATE TABLE `vairuotojas` (
  `Vardas` varchar(255) NOT NULL,
  `Pavarde` varchar(255) NOT NULL,
  `Amzius` int(11) NOT NULL,
  `Telefono_numeris` int(11) NOT NULL,
  `patirtis` int(11) NOT NULL,
  `id_Vairuotojas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vairuotojas`
--

INSERT INTO `vairuotojas` (`Vardas`, `Pavarde`, `Amzius`, `Telefono_numeris`, `patirtis`, `id_Vairuotojas`) VALUES
('Robers', 'Potbury', 32, 2147483647, 2, 1),
('Kassi', 'Danelut', 40, 1154272811, 12, 2),
('Durward', 'Tacon', 46, 2147483647, 13, 3),
('Elisabeth', 'Livsey', 49, 2147483647, 16, 4),
('Llywellyn', 'Osbourne', 47, 2147483647, 19, 5),
('Aili', 'Foldes', 42, 2147483647, 6, 6),
('Ivonne', 'Saunper', 42, 2147483647, 12, 7),
('Major', 'Verecker', 38, 1495109713, 17, 8),
('Tessie', 'Ogus', 42, 2147483647, 6, 9),
('Harbert', 'Horley', 32, 2147483647, 13, 10),
('Norman', 'Mawdsley', 31, 1761216183, 17, 11),
('Lowrance', 'Landsman', 32, 2147483647, 14, 12),
('Elinor', 'Janus', 49, 2147483647, 4, 13),
('Starlene', 'Thornewell', 37, 2147483647, 3, 14),
('Winnifred', 'McGenn', 46, 2147483647, 11, 15),
('Bennie', 'Feeney', 34, 2147483647, 2, 16),
('Harli', 'Brezlaw', 39, 2147483647, 13, 17),
('Yolanthe', 'Dufton', 36, 2147483647, 2, 18),
('Tatiania', 'Scarfe', 47, 2147483647, 15, 19),
('Torey', 'Brabham', 46, 2147483647, 2, 20),
('Elvira', 'Clavering', 49, 2147483647, 15, 21),
('Coleen', 'Surmeir', 37, 2147483647, 13, 22),
('Carrol', 'Ubanks', 42, 2147483647, 7, 23),
('Roanna', 'Osborn', 45, 2147483647, 18, 24),
('Evyn', 'Brydon', 39, 2147483647, 4, 25),
('Maura', 'Gorvin', 47, 2147483647, 16, 26),
('Gennie', 'Chilles', 42, 2147483647, 14, 27),
('Margaux', 'Makey', 37, 2147483647, 3, 28),
('Filippo', 'Ciobutaru', 30, 2147483647, 8, 29),
('Rhett', 'Andrusyak', 39, 2147483647, 20, 30);

-- --------------------------------------------------------

--
-- Table structure for table `vertinimas`
--

CREATE TABLE `vertinimas` (
  `id_Vertinimas` int(11) NOT NULL,
  `name` char(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vertinimas`
--

INSERT INTO `vertinimas` (`id_Vertinimas`, `name`) VALUES
(1, 'Labai_gerai'),
(2, 'Gerai'),
(3, 'Vidutiniskai'),
(4, 'Prastai'),
(5, 'Blogai');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `atsiliepimas`
--
ALTER TABLE `atsiliepimas`
  ADD PRIMARY KEY (`id_Atsiliepimas`),
  ADD KEY `Vertinimas` (`Vertinimas`),
  ADD KEY `paraso` (`fk_Klientasid_Klientas`);

--
-- Indexes for table `atsiskaitymo_budas`
--
ALTER TABLE `atsiskaitymo_budas`
  ADD PRIMARY KEY (`id_Atsiskaitymo_budas`);

--
-- Indexes for table `busena`
--
ALTER TABLE `busena`
  ADD PRIMARY KEY (`id_Busena`);

--
-- Indexes for table `garazas`
--
ALTER TABLE `garazas`
  ADD PRIMARY KEY (`id_Garazas`),
  ADD KEY `priklauso` (`fk_Vairuotojasid_Vairuotojas`);

--
-- Indexes for table `klientas`
--
ALTER TABLE `klientas`
  ADD PRIMARY KEY (`id_Klientas`);

--
-- Indexes for table `krovinys`
--
ALTER TABLE `krovinys`
  ADD PRIMARY KEY (`id_Krovinys`),
  ADD KEY `Pristatymo_busena` (`Pristatymo_busena`),
  ADD KEY `gabenamas` (`fk_Marsrutasid_Marsrutas`),
  ADD KEY `pakraunama` (`fk_Transporto_priemoneid_Transporto_priemone`);

--
-- Indexes for table `marsrutas`
--
ALTER TABLE `marsrutas`
  ADD PRIMARY KEY (`id_Marsrutas`);

--
-- Indexes for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD PRIMARY KEY (`id_Mokejimas`),
  ADD KEY `apmoka` (`fk_Saskaitaid_Saskaita`),
  ADD KEY `sumokejo` (`fk_Klientasid_Klientas`);

--
-- Indexes for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD PRIMARY KEY (`id_Saskaita`);

--
-- Indexes for table `sutarties_busena`
--
ALTER TABLE `sutarties_busena`
  ADD PRIMARY KEY (`id_Sutarties_busena`);

--
-- Indexes for table `tarpine_eilute`
--
ALTER TABLE `tarpine_eilute`
  ADD PRIMARY KEY (`id_Tarpine_eilute`),
  ADD KEY `turi` (`fk_Krovinysid_Krovinys`),
  ADD KEY `tinka` (`fk_Uzsakymasid_Uzsakymas`);

--
-- Indexes for table `transporto_priemone`
--
ALTER TABLE `transporto_priemone`
  ADD PRIMARY KEY (`id_Transporto_priemone`),
  ADD KEY `yra` (`fk_Garazasid_Garazas`);

--
-- Indexes for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  ADD PRIMARY KEY (`id_Uzsakymas`),
  ADD KEY `Uzsakymo_statusas` (`Uzsakymo_statusas`),
  ADD KEY `Sutartis` (`Sutartis`),
  ADD KEY `uzsako` (`fk_Klientasid_Klientas`),
  ADD KEY `priima` (`fk_Vairuotojasid_Vairuotojas`),
  ADD KEY `fk_Atsiliepimasid_Atsiliepimas` (`fk_Atsiliepimasid_Atsiliepimas`) USING BTREE;

--
-- Indexes for table `vairuotojas`
--
ALTER TABLE `vairuotojas`
  ADD PRIMARY KEY (`id_Vairuotojas`);

--
-- Indexes for table `vertinimas`
--
ALTER TABLE `vertinimas`
  ADD PRIMARY KEY (`id_Vertinimas`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `atsiliepimas`
--
ALTER TABLE `atsiliepimas`
  MODIFY `id_Atsiliepimas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `atsiskaitymo_budas`
--
ALTER TABLE `atsiskaitymo_budas`
  MODIFY `id_Atsiskaitymo_budas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `busena`
--
ALTER TABLE `busena`
  MODIFY `id_Busena` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `garazas`
--
ALTER TABLE `garazas`
  MODIFY `id_Garazas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `klientas`
--
ALTER TABLE `klientas`
  MODIFY `id_Klientas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `krovinys`
--
ALTER TABLE `krovinys`
  MODIFY `id_Krovinys` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `marsrutas`
--
ALTER TABLE `marsrutas`
  MODIFY `id_Marsrutas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `mokejimas`
--
ALTER TABLE `mokejimas`
  MODIFY `id_Mokejimas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `saskaita`
--
ALTER TABLE `saskaita`
  MODIFY `id_Saskaita` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `sutarties_busena`
--
ALTER TABLE `sutarties_busena`
  MODIFY `id_Sutarties_busena` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tarpine_eilute`
--
ALTER TABLE `tarpine_eilute`
  MODIFY `id_Tarpine_eilute` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- AUTO_INCREMENT for table `transporto_priemone`
--
ALTER TABLE `transporto_priemone`
  MODIFY `id_Transporto_priemone` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  MODIFY `id_Uzsakymas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;

--
-- AUTO_INCREMENT for table `vairuotojas`
--
ALTER TABLE `vairuotojas`
  MODIFY `id_Vairuotojas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `vertinimas`
--
ALTER TABLE `vertinimas`
  MODIFY `id_Vertinimas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `atsiliepimas`
--
ALTER TABLE `atsiliepimas`
  ADD CONSTRAINT `atsiliepimas_ibfk_1` FOREIGN KEY (`Vertinimas`) REFERENCES `vertinimas` (`id_Vertinimas`),
  ADD CONSTRAINT `paraso` FOREIGN KEY (`fk_Klientasid_Klientas`) REFERENCES `klientas` (`id_Klientas`);

--
-- Constraints for table `garazas`
--
ALTER TABLE `garazas`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_Vairuotojasid_Vairuotojas`) REFERENCES `vairuotojas` (`id_Vairuotojas`);

--
-- Constraints for table `krovinys`
--
ALTER TABLE `krovinys`
  ADD CONSTRAINT `gabenamas` FOREIGN KEY (`fk_Marsrutasid_Marsrutas`) REFERENCES `marsrutas` (`id_Marsrutas`),
  ADD CONSTRAINT `krovinys_ibfk_1` FOREIGN KEY (`Pristatymo_busena`) REFERENCES `busena` (`id_Busena`),
  ADD CONSTRAINT `pakraunama` FOREIGN KEY (`fk_Transporto_priemoneid_Transporto_priemone`) REFERENCES `transporto_priemone` (`id_Transporto_priemone`);

--
-- Constraints for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD CONSTRAINT `apmoka` FOREIGN KEY (`fk_Saskaitaid_Saskaita`) REFERENCES `saskaita` (`id_Saskaita`),
  ADD CONSTRAINT `sumokejo` FOREIGN KEY (`fk_Klientasid_Klientas`) REFERENCES `klientas` (`id_Klientas`);

--
-- Constraints for table `tarpine_eilute`
--
ALTER TABLE `tarpine_eilute`
  ADD CONSTRAINT `tinka` FOREIGN KEY (`fk_Uzsakymasid_Uzsakymas`) REFERENCES `uzsakymas` (`id_Uzsakymas`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Krovinysid_Krovinys`) REFERENCES `krovinys` (`id_Krovinys`);

--
-- Constraints for table `transporto_priemone`
--
ALTER TABLE `transporto_priemone`
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_Garazasid_Garazas`) REFERENCES `garazas` (`id_Garazas`);

--
-- Constraints for table `uzsakymas`
--
ALTER TABLE `uzsakymas`
  ADD CONSTRAINT `priima` FOREIGN KEY (`fk_Vairuotojasid_Vairuotojas`) REFERENCES `vairuotojas` (`id_Vairuotojas`),
  ADD CONSTRAINT `uzsako` FOREIGN KEY (`fk_Klientasid_Klientas`) REFERENCES `klientas` (`id_Klientas`),
  ADD CONSTRAINT `uzsakymas_ibfk_1` FOREIGN KEY (`Uzsakymo_statusas`) REFERENCES `busena` (`id_Busena`),
  ADD CONSTRAINT `uzsakymas_ibfk_2` FOREIGN KEY (`Sutartis`) REFERENCES `sutarties_busena` (`id_Sutarties_busena`),
  ADD CONSTRAINT `vertina` FOREIGN KEY (`fk_Atsiliepimasid_Atsiliepimas`) REFERENCES `atsiliepimas` (`id_Atsiliepimas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
