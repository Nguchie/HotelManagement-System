-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 29, 2016 at 06:40 PM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `justinedb`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbladdons`
--

CREATE TABLE IF NOT EXISTS `tbladdons` (
  `ADONSID` int(11) NOT NULL AUTO_INCREMENT,
  `ADONS` varchar(90) NOT NULL,
  `APRICE` double NOT NULL,
  PRIMARY KEY (`ADONSID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tbladdons`
--

INSERT INTO `tbladdons` (`ADONSID`, `ADONS`, `APRICE`) VALUES
(1, 'PILLOW', 100),
(3, 'Person', 100),
(4, 'BLANKET', 50);

-- --------------------------------------------------------

--
-- Table structure for table `tblautonumber`
--

CREATE TABLE IF NOT EXISTS `tblautonumber` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `AUTOSTART` varchar(11) NOT NULL,
  `AUTOINC` int(11) NOT NULL,
  `AUTOEND` int(11) NOT NULL,
  `AUTOKEY` varchar(12) NOT NULL,
  `AUTONUM` int(30) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `tblautonumber`
--

INSERT INTO `tblautonumber` (`ID`, `AUTOSTART`, `AUTOINC`, `AUTOEND`, `AUTOKEY`, `AUTONUM`) VALUES
(8, '0', 1, 22, 'ROOMID', 5),
(10, '102', 1, 2, 'USERID', 1021),
(11, '1', 1, 68, 'TRANSNUM', 11),
(12, '10', 1, 39, 'GUESTID', 101);

-- --------------------------------------------------------

--
-- Table structure for table `tblextra`
--

CREATE TABLE IF NOT EXISTS `tblextra` (
  `EXTRAID` int(11) NOT NULL AUTO_INCREMENT,
  `ADONSID` int(11) NOT NULL,
  `TRANSNUM` int(11) NOT NULL,
  `EXQTY` int(11) NOT NULL,
  `EXTOTPRICE` double NOT NULL,
  PRIMARY KEY (`EXTRAID`),
  KEY `ADONSID` (`ADONSID`,`TRANSNUM`),
  KEY `TRANSNUM` (`TRANSNUM`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=41 ;

--
-- Dumping data for table `tblextra`
--

INSERT INTO `tblextra` (`EXTRAID`, `ADONSID`, `TRANSNUM`, `EXQTY`, `EXTOTPRICE`) VALUES
(30, 1, 156, 2, 200),
(31, 3, 157, 2, 200),
(32, 1, 157, 2, 200),
(33, 4, 157, 2, 100),
(34, 1, 159, 2, 200),
(35, 4, 159, 2, 100),
(36, 3, 161, 1, 100),
(37, 1, 161, 1, 100),
(38, 4, 161, 1, 50),
(39, 4, 165, 1, 50),
(40, 4, 167, 1, 50);

-- --------------------------------------------------------

--
-- Table structure for table `tblguest`
--

CREATE TABLE IF NOT EXISTS `tblguest` (
  `GUESTID` int(11) NOT NULL AUTO_INCREMENT,
  `G_FNAME` varchar(30) NOT NULL,
  `G_LNAME` varchar(30) NOT NULL,
  `G_ADDRESS` varchar(90) NOT NULL,
  `AGE` int(11) NOT NULL,
  `G_SEX` varchar(11) NOT NULL,
  `G_PHONE` varchar(20) NOT NULL,
  PRIMARY KEY (`GUESTID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1039 ;

--
-- Dumping data for table `tblguest`
--

INSERT INTO `tblguest` (`GUESTID`, `G_FNAME`, `G_LNAME`, `G_ADDRESS`, `AGE`, `G_SEX`, `G_PHONE`) VALUES
(1023, 'Janno', 'Palacios', 'Kabankalan City', 25, 'Male', '222-21343'),
(1024, 'Jamich', 'Lossor', 'Kabankalan city', 23, 'Female', '0323658233'),
(1026, 'SSSS', 'SSS', 'asdasdasdasdas', 22, 'Male', '213213123123'),
(1030, 'oscar', 'ilao', 'brgy 5', 21, 'Male', '03965265'),
(1031, 'Jessa Lyn', 'Jalandoni', '', 80, 'Female', '4582658'),
(1034, 'Janry', 'Tamayo', 'Himamaylan City', 3, 'Male', '098655855485'),
(1035, 'Jacob', 'Tario', 'Goce ilog', 25, 'Male', '0329852'),
(1036, 'Jenilyn', 'Hilario', 'Himamaylan City', 18, 'Female', '097854662445'),
(1037, 'Jerald', 'Anderson', 'Bacolod City', 22, 'Male', '09865854558'),
(1038, 'James', 'Yap', 'Kabakalan City', 33, 'Male', '333-98988');

-- --------------------------------------------------------

--
-- Table structure for table `tblpayment`
--

CREATE TABLE IF NOT EXISTS `tblpayment` (
  `PAYMENTID` int(11) NOT NULL AUTO_INCREMENT,
  `TRANSDATE` datetime NOT NULL,
  `TRANSNUM` int(11) NOT NULL,
  `PQTY` int(11) NOT NULL,
  `GUESTID` int(11) NOT NULL,
  `SPRICE` double NOT NULL,
  `STATUS` varchar(30) NOT NULL,
  `TENDERED` double NOT NULL,
  `CHANGED` double NOT NULL,
  PRIMARY KEY (`PAYMENTID`),
  UNIQUE KEY `TRANSNUM` (`TRANSNUM`),
  KEY `GUESTID` (`GUESTID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=41 ;

--
-- Dumping data for table `tblpayment`
--

INSERT INTO `tblpayment` (`PAYMENTID`, `TRANSDATE`, `TRANSNUM`, `PQTY`, `GUESTID`, `SPRICE`, `STATUS`, `TENDERED`, `CHANGED`) VALUES
(29, '2016-03-29 00:00:00', 156, 1, 1023, 700, 'CHECKED-OUT', 700, 0),
(30, '2016-03-29 00:00:00', 157, 1, 1034, 2000, 'BOOKED', 2000, 0),
(31, '2016-03-29 00:00:00', 158, 1, 1024, 500, 'BOOKED', 500, 0),
(32, '2016-03-29 00:00:00', 159, 1, 1030, 1800, 'CHECKED-OUT', 1800, 0),
(33, '2016-03-29 00:00:00', 160, 1, 1031, 1200, 'CHECKED-OUT', 1200, 0),
(34, '2016-03-29 00:00:00', 161, 1, 1035, 650, 'CHECKED-OUT', 700, 50),
(35, '2016-03-29 00:00:00', 162, 1, 1026, 800, 'CHECKED-OUT', 800, 0),
(36, '2016-03-29 00:00:00', 163, 1, 1036, 800, 'CHECKED-OUT', 800, 0),
(37, '2016-03-29 00:00:00', 164, 1, 1037, 500, 'BOOKED', 500, 0),
(38, '2016-03-29 00:00:00', 165, 1, 1030, 850, 'BOOKED', 900, 50),
(39, '2016-03-29 00:00:00', 166, 1, 1038, 1200, 'BOOKED', 1200, 0),
(40, '2016-03-29 00:00:00', 167, 1, 1038, 1550, 'BOOKED', 1600, 50);

-- --------------------------------------------------------

--
-- Table structure for table `tblreservation`
--

CREATE TABLE IF NOT EXISTS `tblreservation` (
  `RESERVEID` int(11) NOT NULL AUTO_INCREMENT,
  `TRANSNUM` int(11) NOT NULL,
  `TRANSDATE` date NOT NULL,
  `ROOMID` int(11) NOT NULL,
  `ARRIVAL` datetime NOT NULL,
  `DEPARTURE` datetime NOT NULL,
  `RPRICE` double NOT NULL,
  `GUESTID` int(11) NOT NULL,
  `PRORPOSE` varchar(30) NOT NULL,
  `STATUS` varchar(11) NOT NULL,
  `BOOKDATED` date NOT NULL,
  `USERID` int(11) NOT NULL,
  PRIMARY KEY (`RESERVEID`),
  KEY `ROOMID` (`ROOMID`),
  KEY `GUESTID` (`GUESTID`),
  KEY `TRANSNUM` (`TRANSNUM`),
  KEY `USERID` (`USERID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=41 ;

--
-- Dumping data for table `tblreservation`
--

INSERT INTO `tblreservation` (`RESERVEID`, `TRANSNUM`, `TRANSDATE`, `ROOMID`, `ARRIVAL`, `DEPARTURE`, `RPRICE`, `GUESTID`, `PRORPOSE`, `STATUS`, `BOOKDATED`, `USERID`) VALUES
(29, 156, '2016-03-29', 16, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 500, 1023, '', 'BOOKED', '2016-03-29', 1),
(30, 157, '2016-03-29', 18, '2016-03-31 00:00:00', '2016-04-01 00:00:00', 1500, 1034, '', 'BOOKED', '2016-03-29', 1),
(31, 158, '2016-03-29', 15, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 500, 1024, '', 'BOOKED', '2016-03-29', 1),
(32, 159, '2016-03-29', 18, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 1500, 1030, '', 'BOOKED', '2016-03-29', 1),
(33, 160, '2016-03-29', 20, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 1200, 1031, '', 'CHECKED-OUT', '2016-03-29', 1),
(34, 161, '2016-03-29', 17, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 400, 1035, '', 'BOOKED', '2016-03-29', 1),
(35, 162, '2016-03-29', 19, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 800, 1026, '', 'CHECKED-OUT', '2016-03-29', 1),
(36, 163, '2016-03-29', 19, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 800, 1036, '', 'CHECKED-OUT', '2016-03-29', 1),
(37, 164, '2016-03-29', 15, '2016-04-02 00:00:00', '2016-04-03 00:00:00', 500, 1037, '', 'BOOKED', '2016-03-29', 1),
(38, 165, '2016-03-29', 19, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 800, 1030, '', 'BOOKED', '2016-03-29', 1),
(39, 166, '2016-03-29', 20, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 1200, 1038, '', 'RESERVED', '2016-03-29', 1),
(40, 167, '2016-03-29', 18, '2016-03-29 00:00:00', '2016-03-30 00:00:00', 1500, 1038, '', 'BOOKED', '2016-03-29', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tblroom`
--

CREATE TABLE IF NOT EXISTS `tblroom` (
  `ROOMID` int(11) NOT NULL AUTO_INCREMENT,
  `ROOMNUM` int(11) NOT NULL,
  `ROOMTYPEID` int(11) NOT NULL,
  `ROOM` varchar(30) NOT NULL,
  `NUMPERSON` int(11) NOT NULL,
  `PRICE` double NOT NULL,
  PRIMARY KEY (`ROOMID`),
  KEY `ROOMTYPEID` (`ROOMTYPEID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `tblroom`
--

INSERT INTO `tblroom` (`ROOMID`, `ROOMNUM`, `ROOMTYPEID`, `ROOM`, `NUMPERSON`, `PRICE`) VALUES
(15, 3, 12, 'Standard Room', 2, 500),
(16, 2, 12, 'Standard Room', 2, 500),
(17, 4, 18, 'Single Room', 1, 400),
(18, 5, 21, 'Family Deluxe Room', 5, 1500),
(19, 25, 20, 'Family Room', 4, 800),
(20, 24, 19, 'Room Deluxe', 4, 1200);

-- --------------------------------------------------------

--
-- Table structure for table `tblroomtype`
--

CREATE TABLE IF NOT EXISTS `tblroomtype` (
  `ROOMTYPEID` int(11) NOT NULL AUTO_INCREMENT,
  `ROOMTYPE` varchar(30) NOT NULL,
  `DESCRIPTION` varchar(90) NOT NULL,
  PRIMARY KEY (`ROOMTYPEID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `tblroomtype`
--

INSERT INTO `tblroomtype` (`ROOMTYPEID`, `ROOMTYPE`, `DESCRIPTION`) VALUES
(12, 'Standard', 'max 22hrs.'),
(18, 'Single', ''),
(19, 'Deluxe', 'The place of Comfort and Rest'),
(20, 'Family', ''),
(21, 'Family Deluxe', 'The place fo nobles');

-- --------------------------------------------------------

--
-- Table structure for table `tbluseraccount`
--

CREATE TABLE IF NOT EXISTS `tbluseraccount` (
  `USERID` int(11) NOT NULL AUTO_INCREMENT,
  `UNAME` varchar(30) NOT NULL,
  `USER_NAME` varchar(30) NOT NULL,
  `UPASS` varchar(90) NOT NULL,
  `ROLE` varchar(30) NOT NULL,
  PRIMARY KEY (`USERID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `tbluseraccount`
--

INSERT INTO `tbluseraccount` (`USERID`, `UNAME`, `USER_NAME`, `UPASS`, `ROLE`) VALUES
(1, 'Anonymous', 'admin', 'd033e22ae348aeb5660fc2140aec35850c4da997', 'Administrator');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tblextra`
--
ALTER TABLE `tblextra`
  ADD CONSTRAINT `tblextra_ibfk_1` FOREIGN KEY (`ADONSID`) REFERENCES `tbladdons` (`ADONSID`),
  ADD CONSTRAINT `tblextra_ibfk_2` FOREIGN KEY (`TRANSNUM`) REFERENCES `tblpayment` (`TRANSNUM`);

--
-- Constraints for table `tblpayment`
--
ALTER TABLE `tblpayment`
  ADD CONSTRAINT `tblpayment_ibfk_1` FOREIGN KEY (`TRANSNUM`) REFERENCES `tblreservation` (`TRANSNUM`);

--
-- Constraints for table `tblreservation`
--
ALTER TABLE `tblreservation`
  ADD CONSTRAINT `tblreservation_ibfk_1` FOREIGN KEY (`GUESTID`) REFERENCES `tblguest` (`GUESTID`),
  ADD CONSTRAINT `tblreservation_ibfk_2` FOREIGN KEY (`USERID`) REFERENCES `tbluseraccount` (`USERID`),
  ADD CONSTRAINT `tblreservation_ibfk_3` FOREIGN KEY (`ROOMID`) REFERENCES `tblroom` (`ROOMID`);

--
-- Constraints for table `tblroom`
--
ALTER TABLE `tblroom`
  ADD CONSTRAINT `tblroom_ibfk_1` FOREIGN KEY (`ROOMTYPEID`) REFERENCES `tblroomtype` (`ROOMTYPEID`);
