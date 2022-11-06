-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 05, 2022 at 06:54 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `inventory_dotnet_test`
--

-- --------------------------------------------------------

--
-- Table structure for table `asset`
--

CREATE TABLE `asset` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `model` varchar(255) NOT NULL,
  `serial` varchar(255) NOT NULL,
  `purchase_date` datetime(6) NOT NULL,
  `warranty` bigint(20) UNSIGNED NOT NULL,
  `creation_date` datetime(6) NOT NULL,
  `description` longtext NOT NULL,
  `type` smallint(5) UNSIGNED NOT NULL,
  `status` smallint(5) UNSIGNED NOT NULL,
  `user_id` int(11) NOT NULL,
  `next_user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `asset`
--

INSERT INTO `asset` (`id`, `name`, `model`, `serial`, `purchase_date`, `warranty`, `creation_date`, `description`, `type`, `status`, `user_id`, `next_user_id`) VALUES
(1, 'HP Desktop', 'Pavillion', 'ABCD1234', '2021-02-02 15:27:50.000000', 1089, '2022-03-23 15:27:50.000000', 'Normal HP desktop', 1, 0, 5, 4),
(2, 'HP Laptop', 'Specter', 'ABCD1234', '2021-02-02 15:27:50.000000', 1098, '2022-03-23 15:27:50.000000', '', 2, 0, 5, NULL),
(3, 'Epson Printer', 'L565', 'ABCD4321', '1970-01-18 12:46:04.800000', 730, '0001-01-01 00:00:00.000000', 'Color printer with liquid ink...', 3, 0, 4, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `assethistory`
--

CREATE TABLE `assethistory` (
  `id` bigint(20) NOT NULL,
  `creation_date` datetime(6) NOT NULL,
  `asset_id` bigint(20) NOT NULL,
  `from_user_id` int(11) NOT NULL,
  `to_user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `assethistory`
--

INSERT INTO `assethistory` (`id`, `creation_date`, `asset_id`, `from_user_id`, `to_user_id`) VALUES
(1, '2022-04-07 05:30:49.095487', 3, 5, 4);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` longtext DEFAULT NULL,
  `unit` varchar(255) NOT NULL,
  `count` int(10) UNSIGNED NOT NULL,
  `last_modified_date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`id`, `name`, `description`, `unit`, `count`, `last_modified_date`) VALUES
(1, 'Facial Tissue Box', 'Facial tissue box', 'box', 55, '2022-03-20 12:45:06.000000'),
(2, 'Toilet Tissue', 'Toilet tissue', 'unit', 100, '2022-03-20 12:45:23.000000'),
(3, 'Pencil', 'Wood pencil', 'piece', 100, '2022-03-20 12:45:31.000000'),
(4, 'Black Pen', 'Black ball point pen', 'piece', 300, '2022-03-20 12:45:38.000000'),
(5, 'Glue', '', 'unit', 50, '0001-01-01 00:00:00.000000'),
(6, 'Stapler Pin (large)', 'Stapler pin box of large size', 'box', 100, '0001-01-01 00:00:00.000000'),
(7, 'Red pen', 'Red color pen', 'item', 33, '0001-01-01 00:00:00.000000');

-- --------------------------------------------------------

--
-- Table structure for table `leave`
--

CREATE TABLE `leave` (
  `id` bigint(20) NOT NULL,
  `title` varchar(255) NOT NULL,
  `creation_date` datetime(6) NOT NULL,
  `approved` tinyint(1) NOT NULL,
  `approve_date` datetime(6) DEFAULT NULL,
  `start_date` datetime(6) NOT NULL,
  `end_date` datetime(6) NOT NULL,
  `day_count` int(10) UNSIGNED NOT NULL,
  `comment` longtext NOT NULL,
  `approver_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `requisition`
--

CREATE TABLE `requisition` (
  `id` int(11) NOT NULL,
  `approved` tinyint(1) DEFAULT NULL,
  `title` varchar(255) NOT NULL,
  `amount` int(10) UNSIGNED NOT NULL,
  `comment` longtext DEFAULT NULL,
  `approver_id` int(11) NOT NULL,
  `inventory_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `distributed` tinyint(1) DEFAULT NULL,
  `distributor_id` int(11) DEFAULT NULL,
  `approve_date` datetime(6) DEFAULT NULL,
  `distribution_date` datetime(6) DEFAULT NULL,
  `request_date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `password` varchar(128) NOT NULL,
  `last_login` datetime(6) DEFAULT NULL,
  `is_superuser` tinyint(1) NOT NULL,
  `username` varchar(150) DEFAULT NULL,
  `first_name` varchar(150) DEFAULT NULL,
  `last_name` varchar(150) DEFAULT NULL,
  `email` varchar(254) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `date_joined` datetime(6) NOT NULL,
  `supervisor_id` int(11) DEFAULT NULL,
  `can_approve_inventory` tinyint(1) NOT NULL,
  `can_distribute_inventory` tinyint(1) NOT NULL,
  `can_approve_leave` tinyint(1) NOT NULL,
  `can_manage_asset` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `password`, `last_login`, `is_superuser`, `username`, `first_name`, `last_name`, `email`, `is_active`, `date_joined`, `supervisor_id`, `can_approve_inventory`, `can_distribute_inventory`, `can_approve_leave`, `can_manage_asset`) VALUES
(4, '100000.gcd/tzgVo2bdtDi/wQh+fA==.xlKhxENKuXrLQTnXU3nH9gqYBKnx0g13npIfpNRzyOc=', NULL, 0, 'approver', 'Approver', NULL, NULL, 1, '2022-03-21 13:08:04.685672', NULL, 0, 0, 0, 0),
(5, '100000.jPGjnsgpMQZTPmaCnUrHQw==.NIGEHX1cXunn2V2n9hKTxCpDTjeRb9vY3UNHncwzmzw=', NULL, 0, 'shoaib.rahman', 'Mina Shoaib', 'Rahman', 'shoaibsaikat@gmail.com', 1, '2022-03-21 13:31:32.868637', 5, 1, 1, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220319092956_Table creation', '6.0.3'),
('20220321062203_user null fields added', '6.0.3'),
('20220605042959_inventory description made nullable', '6.0.3');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `asset`
--
ALTER TABLE `asset`
  ADD PRIMARY KEY (`id`),
  ADD KEY `asset_next_user_id_0451c2dc_fk_user_id` (`next_user_id`),
  ADD KEY `asset_user_id_54771fbb_fk_user_id` (`user_id`);

--
-- Indexes for table `assethistory`
--
ALTER TABLE `assethistory`
  ADD PRIMARY KEY (`id`),
  ADD KEY `assethistory_asset_id_3b133b1f_fk` (`asset_id`),
  ADD KEY `assethistory_fromUser_id_59c10a11_fk_user_id` (`from_user_id`),
  ADD KEY `assethistory_toUser_id_c48abf98_fk_user_id` (`to_user_id`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `leave`
--
ALTER TABLE `leave`
  ADD PRIMARY KEY (`id`),
  ADD KEY `leave_approver_id_7c2c50d7_fk_user_id` (`approver_id`),
  ADD KEY `leave_user_id_b4b01ea9_fk_user_id` (`user_id`);

--
-- Indexes for table `requisition`
--
ALTER TABLE `requisition`
  ADD PRIMARY KEY (`id`),
  ADD KEY `requisition_approver_id_46fa8cdf_fk_user_id` (`approver_id`),
  ADD KEY `requisition_distributor_id_4f5e5642_fk_user_id` (`distributor_id`),
  ADD KEY `requisition_inventory_id_115ab4a2_fk_inventory` (`inventory_id`),
  ADD KEY `requisition_user_id_c6cdb914_fk_user_id` (`user_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD KEY `user_supervisor_id_479813ed_fk_user_id` (`supervisor_id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `asset`
--
ALTER TABLE `asset`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `assethistory`
--
ALTER TABLE `assethistory`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `leave`
--
ALTER TABLE `leave`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `requisition`
--
ALTER TABLE `requisition`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `asset`
--
ALTER TABLE `asset`
  ADD CONSTRAINT `asset_next_user_id_0451c2dc_fk_user_id` FOREIGN KEY (`next_user_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `asset_user_id_54771fbb_fk_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Constraints for table `assethistory`
--
ALTER TABLE `assethistory`
  ADD CONSTRAINT `assethistory_asset_id_3b133b1f_fk` FOREIGN KEY (`asset_id`) REFERENCES `asset` (`id`),
  ADD CONSTRAINT `assethistory_fromUser_id_59c10a11_fk_user_id` FOREIGN KEY (`from_user_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `assethistory_toUser_id_c48abf98_fk_user_id` FOREIGN KEY (`to_user_id`) REFERENCES `user` (`id`);

--
-- Constraints for table `leave`
--
ALTER TABLE `leave`
  ADD CONSTRAINT `leave_approver_id_7c2c50d7_fk_user_id` FOREIGN KEY (`approver_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `leave_user_id_b4b01ea9_fk_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Constraints for table `requisition`
--
ALTER TABLE `requisition`
  ADD CONSTRAINT `requisition_approver_id_46fa8cdf_fk_user_id` FOREIGN KEY (`approver_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `requisition_distributor_id_4f5e5642_fk_user_id` FOREIGN KEY (`distributor_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `requisition_inventory_id_115ab4a2_fk_inventory` FOREIGN KEY (`inventory_id`) REFERENCES `inventory` (`id`),
  ADD CONSTRAINT `requisition_user_id_c6cdb914_fk_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_supervisor_id_479813ed_fk_user_id` FOREIGN KEY (`supervisor_id`) REFERENCES `user` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
