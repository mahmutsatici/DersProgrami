-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 07 Oca 2024, 17:30:25
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `ders_plani`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `dersler`
--

CREATE TABLE `dersler` (
  `Ders_ID` int(11) NOT NULL,
  `Ders_Adi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `dersler`
--

INSERT INTO `dersler` (`Ders_ID`, `Ders_Adi`) VALUES
(5, 'Lineer Cebir'),
(7, 'Elektrik ve Elektronik Devreler'),
(16, 'Fizik 1'),
(17, 'Fizik 2'),
(18, 'Matematik 1'),
(19, 'Matematik 2'),
(20, 'Algoritma Programlama 1'),
(21, 'Algoritma Programlama 2'),
(22, 'İngilizce 1'),
(23, 'İngilizce 2'),
(24, 'İşletme Ekonomisi'),
(26, 'Ayrık Matematik'),
(27, 'İstatislik ve Olasılık'),
(28, 'Teknik İngilizce');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hocalar`
--

CREATE TABLE `hocalar` (
  `Hoca_ID` int(11) NOT NULL,
  `Hoca_Adi` varchar(50) NOT NULL,
  `Hoca_Sifre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `hocalar`
--

INSERT INTO `hocalar` (`Hoca_ID`, `Hoca_Adi`, `Hoca_Sifre`) VALUES
(17, 'Halil Yigit', '1234'),
(19, 'Zeynep Sarı', ''),
(25, 'Hikmet Hakan Gürel', '12345'),
(26, 'Süleyman Eken', '123235'),
(27, 'Adnan Sondaş', '23432453'),
(28, 'Hikmet Bilgehan Uçar', '1324231'),
(29, 'Önder Yakut', '12345'),
(30, 'Serdar Solak', '13242'),
(31, 'Yavuz Selim Fatihoğlu', '12334'),
(32, 'Gizem Yıldız', '123423'),
(33, 'Seda Balta Kaç', ''),
(34, 'Enes Yurtsever', '12314234'),
(35, 'Halil Yiğit', '245346');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kisitlar`
--

CREATE TABLE `kisitlar` (
  `Hoca_ID` int(11) NOT NULL,
  `Ders_ID` int(11) NOT NULL,
  `Sinif_ID` int(11) NOT NULL,
  `Gun` varchar(10) NOT NULL,
  `Saat` varchar(50) NOT NULL,
  `Kisit_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `kisitlar`
--

INSERT INTO `kisitlar` (`Hoca_ID`, `Ders_ID`, `Sinif_ID`, `Gun`, `Saat`, `Kisit_ID`) VALUES
(35, 28, 4, 'Pazartesi', '09.00 - 10.00', 32),
(35, 28, 4, 'Pazartesi', '10.00 - 11.00', 33),
(34, 26, 3, 'Pazartesi', '11.00 - 12.00', 34),
(34, 26, 1, 'Perşembe', '11.00 - 12.00', 35),
(33, 24, 4, 'Salı', '12.00 - 13.00', 36),
(33, 24, 4, 'Salı', '13.00 - 14.00', 37),
(33, 24, 4, 'Salı', '14.00 - 15.00', 38),
(30, 27, 4, 'Salı', '09.00 - 10.00', 39),
(30, 27, 4, 'Salı', '10.00 - 11.00', 40),
(34, 26, 3, 'Pazartesi', '09.00 - 10.00', 41),
(34, 26, 3, 'Pazartesi', '10.00 - 11.00', 42),
(32, 19, 3, 'Pazartesi', '13.00 - 14.00', 43),
(32, 19, 3, 'Pazartesi', '14.00 - 15.00', 44),
(32, 19, 2, 'Cuma', '12.00 - 13.00', 45),
(32, 19, 2, 'Cuma', '13.00 - 14.00', 46),
(25, 21, 1, 'Çarşamba', '11.00 - 12.00', 47),
(25, 21, 1, 'Çarşamba', '12.00 - 13.00', 48),
(33, 18, 3, 'Çarşamba', '09.00 - 10.00', 49),
(35, 28, 4, 'Cuma', '09.00 - 10.00', 50);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `siniflar`
--

CREATE TABLE `siniflar` (
  `Sinif_ID` int(11) NOT NULL,
  `Sinif_Adi` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_turkish_ci;

--
-- Tablo döküm verisi `siniflar`
--

INSERT INTO `siniflar` (`Sinif_ID`, `Sinif_Adi`) VALUES
(1, '1040'),
(2, '1041'),
(3, '1044'),
(4, '1036');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `dersler`
--
ALTER TABLE `dersler`
  ADD PRIMARY KEY (`Ders_ID`);

--
-- Tablo için indeksler `hocalar`
--
ALTER TABLE `hocalar`
  ADD PRIMARY KEY (`Hoca_ID`);

--
-- Tablo için indeksler `kisitlar`
--
ALTER TABLE `kisitlar`
  ADD PRIMARY KEY (`Kisit_ID`),
  ADD KEY `Ders_ID` (`Ders_ID`),
  ADD KEY `Sinif_ID` (`Sinif_ID`),
  ADD KEY `kisitlar_ibfk_1` (`Hoca_ID`);

--
-- Tablo için indeksler `siniflar`
--
ALTER TABLE `siniflar`
  ADD PRIMARY KEY (`Sinif_ID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `dersler`
--
ALTER TABLE `dersler`
  MODIFY `Ders_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Tablo için AUTO_INCREMENT değeri `hocalar`
--
ALTER TABLE `hocalar`
  MODIFY `Hoca_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- Tablo için AUTO_INCREMENT değeri `kisitlar`
--
ALTER TABLE `kisitlar`
  MODIFY `Kisit_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- Tablo için AUTO_INCREMENT değeri `siniflar`
--
ALTER TABLE `siniflar`
  MODIFY `Sinif_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `kisitlar`
--
ALTER TABLE `kisitlar`
  ADD CONSTRAINT `kisitlar_ibfk_1` FOREIGN KEY (`Hoca_ID`) REFERENCES `hocalar` (`Hoca_ID`),
  ADD CONSTRAINT `kisitlar_ibfk_2` FOREIGN KEY (`Ders_ID`) REFERENCES `dersler` (`Ders_ID`),
  ADD CONSTRAINT `kisitlar_ibfk_3` FOREIGN KEY (`Sinif_ID`) REFERENCES `siniflar` (`Sinif_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
