-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 08, 2023 at 10:37 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `asset`
--

INSERT INTO `asset` (`id`, `name`, `model`, `serial`, `purchase_date`, `warranty`, `creation_date`, `description`, `type`, `status`, `user_id`, `next_user_id`) VALUES
(1, 'HP Desktop', 'Pavillion', 'ABCD1234', '2021-02-02 15:27:50.000000', 1089, '2022-03-23 15:27:50.000000', 'Normal HP desktop', 1, 0, 5, NULL),
(2, 'HP Laptop', 'Specter', 'ABCD1234', '2021-02-02 15:27:50.000000', 1098, '2022-03-23 15:27:50.000000', '', 2, 0, 5, NULL),
(3, 'Epson Printer', 'L565', 'ABCD4321', '1970-01-18 12:46:04.800000', 730, '0001-01-01 00:00:00.000000', 'Color printer with liquid ink...', 3, 0, 4, NULL),
(5, 'HP Printer', 'HP LaserJet 107a', 'ABCD', '1970-01-20 00:05:45.600000', 365, '0001-01-01 00:00:00.000000', 'Monochrome printer', 3, 0, 6, NULL),
(6, 'Dell Desktop', 'Dell OptiPlex 3090', 'ABCD', '1970-01-20 05:18:14.400000', 365, '0001-01-01 00:00:00.000000', 'Dell desktop', 1, 0, 6, NULL),
(7, 'HP Spectre x360', 'HP Spectre x360', 'ABCD', '1970-01-19 19:43:40.800000', 365, '0001-01-01 00:00:00.000000', '', 2, 0, 4, NULL);

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `assethistory`
--

INSERT INTO `assethistory` (`id`, `creation_date`, `asset_id`, `from_user_id`, `to_user_id`) VALUES
(1, '2022-04-07 05:30:49.095487', 3, 5, 4),
(3, '2023-01-01 08:14:39.973010', 5, 6, 6),
(4, '2023-01-01 08:15:53.093589', 6, 6, 6),
(5, '2023-01-01 08:19:37.412216', 7, 6, 6),
(6, '2023-01-01 08:24:42.189388', 7, 6, 4);

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`id`, `name`, `description`, `unit`, `count`, `last_modified_date`) VALUES
(1, 'Facial Tissue Box', 'Facial tissue box', 'box', 57, '2022-12-29 06:44:26.433050'),
(2, 'Toilet Tissue', 'Toilet tissue', 'unit', 96, '2023-01-01 09:43:43.339897'),
(3, 'Pencil', 'Wood pencil', 'piece', 100, '2023-01-01 09:43:04.434700'),
(4, 'Black Pen', 'Black ball point pen', 'piece', 155, '2022-03-20 12:45:38.000000'),
(5, 'Glue', '', 'unit', 49, '0001-01-01 00:00:00.000000'),
(6, 'Stapler Pin (large)', 'Stapler pin box of large size', 'box', 98, '2022-12-27 08:42:27.372830'),
(7, 'Red pen', 'Red color pen', 'item', 33, '0001-01-01 00:00:00.000000'),
(8, 'Cloth Duster', 'Cloth duster for cleaning work', 'piece', 39, '0001-01-01 00:00:00.000000'),
(9, 'Handwash refill', 'Refill packet for handwash', 'packet', 80, '0001-01-01 00:00:00.000000'),
(10, 'Stapler', '', 'piece', 30, '0001-01-01 00:00:00.000000'),
(11, 'Punch machine (double punch)', '', 'piece', 20, '0001-01-01 00:00:00.000000'),
(12, 'Punch machine (single punch)', '', 'piece', 35, '0001-01-01 00:00:00.000000'),
(13, 'Paperweight', 'Glass paperweight', 'piece', 42, '0001-01-01 00:00:00.000000'),
(14, 'Hand sanitizer', 'Liquid hand sanitizer', 'bottle', 30, '2023-01-01 09:45:16.067071');

-- --------------------------------------------------------

--
-- Table structure for table `leave`
--

CREATE TABLE `leave` (
  `id` bigint(20) NOT NULL,
  `title` varchar(255) NOT NULL,
  `creation_date` datetime(6) NOT NULL,
  `approved` tinyint(1) DEFAULT NULL,
  `approve_date` datetime(6) DEFAULT NULL,
  `start_date` datetime(6) NOT NULL,
  `end_date` datetime(6) NOT NULL,
  `day_count` int(10) UNSIGNED NOT NULL,
  `comment` longtext NOT NULL,
  `approver_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `leave`
--

INSERT INTO `leave` (`id`, `title`, `creation_date`, `approved`, `approve_date`, `start_date`, `end_date`, `day_count`, `comment`, `approver_id`, `user_id`) VALUES
(2, 'A one-day leave needed', '0001-01-01 00:00:00.000000', 1, '2022-12-22 06:59:33.151367', '2022-12-22 00:00:00.000000', '2022-12-22 00:00:00.000000', 1, 'A one-day leave needed due to sickness.', 7, 5),
(3, 'Two days leave needed', '0001-01-01 00:00:00.000000', 0, '2023-01-02 08:54:52.476249', '2023-01-25 00:00:00.000000', '2023-01-26 00:00:00.000000', 2, '2 days leave needed due to family visit in next year.', 7, 5),
(13, 'One day leave needed', '2022-12-27 08:16:14.711885', 1, '2022-12-27 08:33:55.170764', '2022-12-28 00:00:00.000000', '2022-12-28 00:00:00.000000', 1, 'One day leave needed', 7, 4),
(14, 'Two days leave needed', '2022-12-27 08:16:50.414138', 1, '2022-12-27 08:33:15.073242', '2022-12-28 00:00:00.000000', '2022-12-29 00:00:00.000000', 2, '2 days leave needed', 7, 6),
(15, 'One day leave needed', '2023-01-02 08:16:14.762217', 0, '2023-01-02 08:54:55.371103', '2023-02-05 00:00:00.000000', '2023-02-05 00:00:00.000000', 1, 'One day leave needed', 7, 6),
(16, 'Three days leave needed', '2023-01-02 08:16:47.751249', 1, '2023-01-02 08:54:28.630476', '2023-01-03 00:00:00.000000', '2023-01-03 00:00:00.000000', 1, '3 days leave needed', 7, 4);

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `requisition`
--

INSERT INTO `requisition` (`id`, `approved`, `title`, `amount`, `comment`, `approver_id`, `inventory_id`, `user_id`, `distributed`, `distributor_id`, `approve_date`, `distribution_date`, `request_date`) VALUES
(1, 1, 'A pencil needed', 1, 'Pencil is needed to make draft', 4, 3, 5, 1, 6, '2022-12-27 04:30:09.009867', '2022-12-27 08:39:20.687072', '2022-12-22 01:28:04.347216'),
(2, 1, 'Glue needed', 1, 'Glue needed for stationary work', 4, 5, 4, 1, 6, NULL, '2022-12-22 07:37:29.263552', '2022-12-22 01:37:14.845981'),
(3, 1, 'One tissue paper needed', 1, '', 4, 1, 5, NULL, 6, '2022-12-27 04:30:06.464524', NULL, '2022-12-22 05:32:57.641430'),
(4, 0, 'A glue stick needed', 1, '', 4, 5, 5, NULL, NULL, '2023-01-02 07:53:34.608565', NULL, '2022-12-27 04:27:07.578826'),
(5, 1, 'A cloth duster needed', 1, '', 4, 8, 5, 1, 6, '2022-12-27 04:30:12.773358', '2022-12-27 04:45:15.097698', '2022-12-27 04:27:20.528775'),
(6, 1, 'A punch machine needed', 1, '', 4, 11, 5, NULL, 6, '2023-01-02 08:13:30.685148', NULL, '2022-12-27 04:27:32.606736'),
(7, 0, 'A paperweight needed', 1, '', 4, 13, 5, NULL, NULL, '2023-01-02 07:52:58.205726', NULL, '2022-12-27 04:27:44.231213'),
(8, 0, 'A handwash refill needed', 1, '', 4, 9, 4, NULL, NULL, '2023-01-02 08:13:19.698345', NULL, '2023-01-02 06:51:06.712001'),
(9, 1, ' A pencil needed', 1, '', 4, 3, 4, NULL, 6, '2023-01-02 08:13:25.341865', NULL, '2023-01-02 06:51:44.279135');

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `password`, `last_login`, `is_superuser`, `username`, `first_name`, `last_name`, `email`, `is_active`, `date_joined`, `supervisor_id`, `can_approve_inventory`, `can_distribute_inventory`, `can_approve_leave`, `can_manage_asset`) VALUES
(4, '100000.gcd/tzgVo2bdtDi/wQh+fA==.xlKhxENKuXrLQTnXU3nH9gqYBKnx0g13npIfpNRzyOc=', NULL, 0, 'approver', 'Approver', NULL, NULL, 1, '2022-03-21 13:08:04.685672', 7, 1, 0, 0, 1),
(5, '100000.jPGjnsgpMQZTPmaCnUrHQw==.NIGEHX1cXunn2V2n9hKTxCpDTjeRb9vY3UNHncwzmzw=', NULL, 0, 'shoaib.rahman', 'Mina Shoaib', 'Rahman', 'shoaib.rahman@beza.gov.bd', 1, '2022-03-21 13:31:32.868637', 7, 0, 0, 0, 0),
(6, '100000.xmocMvZiMdVzupx6r9dRPw==.xPJqx0q8mPCDnWDmrSYcETRFR4j1S+YnyVgLeVbmD6M=', NULL, 0, 'distributor', 'Distributor', NULL, NULL, 1, '2022-12-22 07:26:35.999722', 7, 0, 1, 0, 1),
(7, '100000.quwqWcaFAzk3Wq1sV+L7cw==.LrOoDUK6tuf2zoe8R1mfeJZixekM34DO9cjJiTE2lyk=', NULL, 0, 'manager', 'Manager', 'Office', 'abcd@abcd.com', 1, '2022-12-22 09:42:56.834157', 7, 0, 0, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220319092956_Table creation', '6.0.3'),
('20220321062203_User null fields added', '6.0.3'),
('20220605042959_Inventory description made nullable', '6.0.3'),
('20230102070707_Leave approval nullable', '6.0.10'),
('20230102144000_Dotnet upgrade', '7.0.1');

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
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `assethistory`
--
ALTER TABLE `assethistory`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `leave`
--
ALTER TABLE `leave`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `requisition`
--
ALTER TABLE `requisition`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

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
