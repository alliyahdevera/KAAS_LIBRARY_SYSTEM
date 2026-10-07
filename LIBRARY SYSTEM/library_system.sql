-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 07, 2026 at 01:45 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `library_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `activitylogs`
--

CREATE TABLE `activitylogs` (
  `log_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `action` varchar(100) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `log_time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `activitylogs`
--

INSERT INTO `activitylogs` (`log_id`, `user_id`, `action`, `description`, `log_time`) VALUES
(1, 1, 'Import Books', '24 book record(s) imported from Excel file.', '2026-07-31 18:02:59'),
(2, 1, 'Add Book', 'Added \'A Tale of Two Cities\' (ISBN 9780141439518)', '2026-07-31 18:03:23'),
(3, 1, 'Import Books', '24 book record(s) imported from Excel file.', '2026-08-01 19:28:08'),
(4, 3, 'Import Books', '24 book record(s) imported from Excel file.', '2026-08-01 19:29:46'),
(5, 1, 'Add Book', 'Added \'English Grammar in Use\' (ISBN 9780135191439)', '2026-08-02 14:47:55'),
(6, 3, 'Penalty Management', 'Marked transaction #6 penalty as Paid.', '2026-08-02 15:16:26'),
(7, 3, 'Verify Record', 'Verified transaction #13 as Good — no penalty', '2026-08-02 17:30:18'),
(8, 3, 'Verify Record', 'Verified transaction #14 as Damaged — penalty ₱520.00', '2026-08-02 17:31:46'),
(9, 3, 'Update Penalty', 'Updated transaction #14 — condition Damaged, amount ₱520.00, status Paid', '2026-08-02 18:20:40'),
(10, 3, 'Update Penalty', 'Updated transaction #14 — condition Damaged, amount ₱520.00, status Paid', '2026-08-02 18:20:56'),
(11, 3, 'Verify Record', 'Verified transaction #15 as Good — no penalty', '2026-08-02 18:37:09'),
(12, 3, 'Verify Record', 'Verified transaction #15 as Damaged — penalty ₱1,300.00', '2026-08-02 18:37:42'),
(13, 3, 'Verify Record', 'Verified transaction #12 as Lost — penalty ₱749.00', '2026-08-02 18:58:08'),
(14, 3, 'Verify Record', 'Verified transaction #16 as Damaged — penalty ₱2,150.00', '2026-08-02 19:51:05'),
(15, 3, 'Update Penalty', 'Updated transaction #16 — condition Damaged, amount ₱2,150.00, status Paid', '2026-08-02 19:54:40'),
(16, 3, 'Update Penalty', 'Updated transaction #16 — condition Damaged, amount ₱2,150.00, status Paid', '2026-08-02 19:56:40'),
(17, 3, 'Verify Record', 'Verified transaction #17 as Lost — penalty ₱750.00', '2026-08-02 20:07:42'),
(18, 3, 'Update Penalty', 'Updated transaction #17 — condition Lost, amount ₱750.00, status Unpaid', '2026-08-02 20:07:51'),
(19, 3, 'Update Penalty', 'Updated transaction #17 — condition Lost, amount ₱750.00, status Unpaid', '2026-08-02 20:07:55'),
(20, 3, 'Update Penalty', 'Updated transaction #17 — condition Lost, amount ₱750.00, status Paid', '2026-08-02 20:08:09'),
(21, 3, 'Verify Record', 'Verified transaction #18 as Damaged — penalty ₱680.00', '2026-08-02 20:44:23'),
(22, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Paid', '2026-08-02 20:44:46'),
(23, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Unpaid', '2026-08-02 20:45:28'),
(24, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Paid', '2026-08-02 20:46:10'),
(25, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Unpaid', '2026-08-02 20:46:40'),
(26, 3, 'Update Penalty', 'Updated transaction #6 — condition Good, amount ₱450.00, status Unpaid', '2026-08-02 20:48:58'),
(27, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Paid', '2026-08-02 22:30:42'),
(28, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:21:31'),
(29, 1, 'Logout', 'A_admin logged out.', '2026-10-06 12:23:06'),
(30, 1, 'Update Account', 'Updated account \'kevinn\' (status Active).', '2026-10-06 12:23:42'),
(31, 1, 'Logout', 'A_admin logged out.', '2026-10-06 12:23:47'),
(32, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:24:28'),
(33, 5, 'Logout', 'kcer logged out.', '2026-10-06 12:26:30'),
(34, 1, 'Add Account', 'Created Student account \'alliyah\'.', '2026-10-06 12:29:15'),
(35, 1, 'Add Account', 'Created Teacher account \'teacher\'.', '2026-10-06 12:30:32'),
(36, 1, 'Add Account', 'Created Librarian account \'librarian\'.', '2026-10-06 12:32:41'),
(37, 1, 'Deactivate Account', 'Set account \'kcer\' to Inactive.', '2026-10-06 12:33:28'),
(38, 1, 'Update Account', 'Updated account \'kcer\' (status Active).', '2026-10-06 12:33:41'),
(39, 1, 'Logout', 'A_admin logged out.', '2026-10-06 12:34:42'),
(40, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:35:10'),
(41, 10, 'Update Book', 'Updated \'Computer Networking: A Top-Down Approach\' (ISBN 9780135166307)', '2026-10-06 12:37:25'),
(42, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:37:51'),
(43, 7, 'Borrow', 'kevinn borrowed 1 book(s).', '2026-10-06 12:39:24'),
(44, 7, 'Return', 'kevinn returned 1 book(s).', '2026-10-06 12:39:39'),
(45, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:39:45'),
(46, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:39:58'),
(47, 10, 'Verify Record', 'Verified transaction #21 as Good - no penalty', '2026-10-06 12:40:27'),
(48, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:40:49'),
(49, 7, 'Borrow', 'kevinn borrowed 3 book(s).', '2026-10-06 12:42:25'),
(50, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:42:28'),
(51, 7, 'Return', 'kevinn returned 3 book(s).', '2026-10-06 12:42:46'),
(52, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:42:49'),
(53, 10, 'Verify Record', 'Verified transaction #24 as Damaged - penalty ₱2,450.00', '2026-10-06 12:43:13'),
(54, 10, 'Verify Record', 'Verified transaction #23 as Lost - penalty ₱2,150.00', '2026-10-06 12:43:22'),
(55, 10, 'Verify Record', 'Verified transaction #22 as Good - no penalty', '2026-10-06 12:43:31'),
(56, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:43:41'),
(57, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:44:51'),
(58, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:45:02'),
(59, 10, 'Update Penalty', 'Updated transaction #24 - condition Damaged, amount ₱2,450.00, status Paid', '2026-10-06 12:45:34'),
(60, 10, 'Update Penalty', 'Updated transaction #24 - condition Damaged, amount ₱2,450.00, status Paid', '2026-10-06 12:45:48'),
(61, 10, 'Update Penalty', 'Updated transaction #23 - condition Lost, amount ₱2,150.00, status Unpaid', '2026-10-06 12:45:56'),
(62, 10, 'Update Penalty', 'Updated transaction #23 - condition Lost, amount ₱2,150.00, status Paid', '2026-10-06 12:46:02'),
(63, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:46:06'),
(64, 7, 'Logout', 'kevinn logged out.', '2026-10-06 12:46:49'),
(65, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (4 records)', '2026-10-06 12:48:16'),
(66, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (4 records)', '2026-10-06 12:48:23'),
(67, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (0 records)', '2026-10-06 12:49:24'),
(68, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (0 records)', '2026-10-06 12:49:29'),
(69, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (0 records)', '2026-10-06 12:49:34'),
(70, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (4 records)', '2026-10-06 12:49:37'),
(71, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (1 records)', '2026-10-06 12:49:47'),
(72, 1, 'Generate Report', 'Report 10/01/2026 to 10/06/2026 (1 records)', '2026-10-06 12:50:13'),
(73, 1, 'Logout', 'A_admin logged out.', '2026-10-06 12:50:41'),
(74, 10, 'Logout', 'librarian logged out.', '2026-10-06 12:51:19'),
(75, 6, 'Return', 'Tailor returned 1 book(s).', '2026-10-06 13:06:06'),
(76, 6, 'Logout', 'Tailor logged out.', '2026-10-06 13:12:37'),
(77, 10, 'Logout', 'librarian logged out.', '2026-10-07 14:44:32'),
(78, 10, 'Logout', 'librarian logged out.', '2026-10-07 15:01:34'),
(79, 6, 'Logout', 'Tailor logged out.', '2026-10-07 16:14:57'),
(80, 10, 'Logout', 'librarian logged out.', '2026-10-07 16:15:37'),
(81, 1, 'Recovered Book', 'Book no. 6 marked as recovered / repaired', '2026-10-07 19:31:00'),
(82, 1, 'Recovered Book', 'Book no. 9 marked as recovered / repaired', '2026-10-07 19:36:22'),
(83, 1, 'Logout', 'A_admin logged out.', '2026-10-07 19:37:17'),
(84, 3, 'Logout', 'A_Librarian logged out.', '2026-10-07 19:38:40'),
(85, 3, 'Logout', 'A_Librarian logged out.', '2026-10-07 19:39:02');

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `author_id` int(11) NOT NULL,
  `author_name` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`author_id`, `author_name`) VALUES
(19, 'Anita Woolfolk'),
(2, 'Charles Dickens'),
(21, 'E.H. Gombrich'),
(3, 'F. Scott Fitzgerald'),
(4, 'Frank Herbert'),
(7, 'Gillian Flynn'),
(1, 'J.K. Rowling'),
(5, 'J.R.R. Tolkien'),
(15, 'James F. Kurose'),
(17, 'James Stewart'),
(13, 'Jared Diamond'),
(22, 'Lonely Planet'),
(14, 'Marcus Aurelius'),
(23, 'Merriam-Webster'),
(24, 'National Geographic'),
(6, 'Nicholas Sparks'),
(18, 'Philip Kotler'),
(20, 'Raymond Murphy'),
(9, 'Stephen King'),
(8, 'Stieg Larsson'),
(10, 'Suzanne Collins'),
(12, 'Walter Isaacson'),
(16, 'Y. Daniel Liang'),
(11, 'Yuval Noah Harari');

-- --------------------------------------------------------

--
-- Table structure for table `bookauthors`
--

CREATE TABLE `bookauthors` (
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  `author_order` tinyint(4) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookauthors`
--

INSERT INTO `bookauthors` (`book_id`, `author_id`, `author_order`) VALUES
(1, 6, 1),
(2, 7, 1),
(3, 11, 1),
(4, 17, 1),
(5, 19, 1),
(6, 15, 1),
(7, 20, 1),
(8, 16, 1),
(9, 14, 1),
(10, 2, 1),
(11, 13, 1),
(12, 23, 1),
(13, 8, 1),
(14, 9, 1),
(15, 10, 1),
(16, 1, 1),
(17, 21, 1),
(18, 5, 1),
(19, 4, 1),
(20, 3, 1),
(21, 18, 1),
(22, 24, 1),
(23, 12, 1),
(24, 22, 1);

--
-- Triggers `bookauthors`
--
DELIMITER $$
CREATE TRIGGER `trg_bookauthors_max2` BEFORE INSERT ON `bookauthors` FOR EACH ROW BEGIN
  IF (SELECT COUNT(*) FROM `BookAuthors` WHERE `book_id` = NEW.`book_id`) >= 2 THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'A book can have at most 2 authors.';
  END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `bookcategories`
--

CREATE TABLE `bookcategories` (
  `book_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookcategories`
--

INSERT INTO `bookcategories` (`book_id`, `category_id`) VALUES
(1, 6),
(2, 7),
(3, 11),
(4, 17),
(5, 19),
(6, 15),
(7, 20),
(8, 16),
(9, 14),
(10, 2),
(11, 13),
(12, 23),
(13, 8),
(14, 9),
(15, 10),
(16, 1),
(17, 21),
(18, 5),
(19, 4),
(20, 3),
(21, 18),
(22, 24),
(23, 12),
(24, 22);

-- --------------------------------------------------------

--
-- Table structure for table `bookcopies`
--

CREATE TABLE `bookcopies` (
  `copy_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `accession_no` varchar(30) NOT NULL,
  `copy_status` enum('Available','Borrowed','Lost','Damaged','Archived') NOT NULL DEFAULT 'Available',
  `book_condition` enum('New','Good','Fair','Poor','Damaged','Lost') NOT NULL DEFAULT 'Good',
  `date_added` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookcopies`
--

INSERT INTO `bookcopies` (`copy_id`, `book_id`, `accession_no`, `copy_status`, `book_condition`, `date_added`) VALUES
(1, 16, 'ACC-00001', 'Available', 'Good', '2026-07-31 10:02:59'),
(2, 10, 'ACC-00002', 'Lost', 'Lost', '2026-07-31 10:02:59'),
(3, 20, 'ACC-00003', 'Available', 'Good', '2026-07-31 10:02:59'),
(4, 19, 'ACC-00004', 'Available', 'Good', '2026-07-31 10:02:59'),
(5, 18, 'ACC-00005', 'Available', 'Good', '2026-07-31 10:02:59'),
(6, 1, 'ACC-00006', 'Available', 'Good', '2026-07-31 10:02:59'),
(7, 2, 'ACC-00007', 'Available', 'Good', '2026-07-31 10:02:59'),
(8, 13, 'ACC-00008', 'Available', 'Good', '2026-07-31 10:02:59'),
(9, 14, 'ACC-00009', 'Available', 'Good', '2026-07-31 10:02:59'),
(10, 15, 'ACC-00010', 'Damaged', 'Damaged', '2026-07-31 10:02:59'),
(11, 3, 'ACC-00011', 'Available', 'Good', '2026-07-31 10:02:59'),
(12, 23, 'ACC-00012', 'Available', 'Good', '2026-07-31 10:02:59'),
(13, 11, 'ACC-00013', 'Available', 'Good', '2026-07-31 10:02:59'),
(14, 9, 'ACC-00014', 'Available', 'Good', '2026-07-31 10:02:59'),
(15, 6, 'ACC-00015', 'Damaged', 'Damaged', '2026-07-31 10:02:59'),
(16, 8, 'ACC-00016', 'Available', 'Good', '2026-07-31 10:02:59'),
(17, 4, 'ACC-00017', 'Lost', 'Lost', '2026-07-31 10:02:59'),
(18, 21, 'ACC-00018', 'Available', 'Good', '2026-07-31 10:02:59'),
(19, 5, 'ACC-00019', 'Available', 'Good', '2026-07-31 10:02:59'),
(20, 7, 'ACC-00020', 'Available', 'Good', '2026-07-31 10:02:59'),
(21, 17, 'ACC-00021', 'Available', 'Good', '2026-07-31 10:02:59'),
(22, 24, 'ACC-00022', 'Damaged', 'Damaged', '2026-07-31 10:02:59'),
(23, 12, 'ACC-00023', 'Available', 'Good', '2026-07-31 10:02:59'),
(24, 22, 'ACC-00024', 'Available', 'Good', '2026-07-31 10:02:59'),
(25, 10, 'ACC-00025', 'Available', 'Good', '2026-07-31 10:03:23'),
(26, 16, 'ACC-00026', 'Available', 'Good', '2026-08-01 11:28:08'),
(27, 10, 'ACC-00027', 'Available', 'Good', '2026-08-01 11:28:08'),
(28, 20, 'ACC-00028', 'Available', 'Good', '2026-08-01 11:28:08'),
(29, 19, 'ACC-00029', 'Available', 'Good', '2026-08-01 11:28:08'),
(30, 18, 'ACC-00030', 'Available', 'Good', '2026-08-01 11:28:08'),
(31, 1, 'ACC-00031', 'Borrowed', 'Good', '2026-08-01 11:28:08'),
(32, 2, 'ACC-00032', 'Available', 'Good', '2026-08-01 11:28:08'),
(33, 13, 'ACC-00033', 'Available', 'Good', '2026-08-01 11:28:08'),
(34, 14, 'ACC-00034', 'Available', 'Good', '2026-08-01 11:28:08'),
(35, 15, 'ACC-00035', 'Available', 'Good', '2026-08-01 11:28:08'),
(36, 3, 'ACC-00036', 'Available', 'Good', '2026-08-01 11:28:08'),
(37, 23, 'ACC-00037', 'Available', 'Good', '2026-08-01 11:28:08'),
(38, 11, 'ACC-00038', 'Available', 'Good', '2026-08-01 11:28:08'),
(39, 9, 'ACC-00039', 'Available', 'Good', '2026-08-01 11:28:08'),
(40, 6, 'ACC-00040', 'Available', 'Good', '2026-08-01 11:28:08'),
(41, 8, 'ACC-00041', 'Available', 'Good', '2026-08-01 11:28:08'),
(42, 4, 'ACC-00042', 'Available', 'Good', '2026-08-01 11:28:08'),
(43, 21, 'ACC-00043', 'Available', 'Good', '2026-08-01 11:28:08'),
(44, 5, 'ACC-00044', 'Available', 'Good', '2026-08-01 11:28:08'),
(45, 7, 'ACC-00045', 'Available', 'Good', '2026-08-01 11:28:08'),
(46, 17, 'ACC-00046', 'Available', 'Good', '2026-08-01 11:28:08'),
(47, 24, 'ACC-00047', 'Available', 'Good', '2026-08-01 11:28:08'),
(48, 12, 'ACC-00048', 'Available', 'Good', '2026-08-01 11:28:08'),
(49, 22, 'ACC-00049', 'Available', 'Good', '2026-08-01 11:28:08'),
(50, 16, 'ACC-00050', 'Available', 'Good', '2026-08-01 11:29:46'),
(51, 10, 'ACC-00051', 'Available', 'Good', '2026-08-01 11:29:46'),
(52, 20, 'ACC-00052', 'Available', 'Good', '2026-08-01 11:29:46'),
(53, 19, 'ACC-00053', 'Available', 'Good', '2026-08-01 11:29:46'),
(54, 18, 'ACC-00054', 'Available', 'Good', '2026-08-01 11:29:46'),
(55, 1, 'ACC-00055', 'Available', 'Good', '2026-08-01 11:29:46'),
(56, 2, 'ACC-00056', 'Available', 'Good', '2026-08-01 11:29:46'),
(57, 13, 'ACC-00057', 'Available', 'Good', '2026-08-01 11:29:46'),
(58, 14, 'ACC-00058', 'Available', 'Good', '2026-08-01 11:29:46'),
(59, 15, 'ACC-00059', 'Available', 'Good', '2026-08-01 11:29:46'),
(60, 3, 'ACC-00060', 'Available', 'Good', '2026-08-01 11:29:46'),
(61, 23, 'ACC-00061', 'Available', 'Good', '2026-08-01 11:29:46'),
(62, 11, 'ACC-00062', 'Available', 'Good', '2026-08-01 11:29:46'),
(63, 9, 'ACC-00063', 'Available', 'Good', '2026-08-01 11:29:46'),
(64, 6, 'ACC-00064', 'Available', 'Good', '2026-08-01 11:29:46'),
(65, 8, 'ACC-00065', 'Available', 'Good', '2026-08-01 11:29:46'),
(66, 4, 'ACC-00066', 'Available', 'Good', '2026-08-01 11:29:46'),
(67, 21, 'ACC-00067', 'Available', 'Good', '2026-08-01 11:29:46'),
(68, 5, 'ACC-00068', 'Available', 'Good', '2026-08-01 11:29:46'),
(69, 7, 'ACC-00069', 'Available', 'Good', '2026-08-01 11:29:46'),
(70, 17, 'ACC-00070', 'Available', 'Good', '2026-08-01 11:29:46'),
(71, 24, 'ACC-00071', 'Available', 'Good', '2026-08-01 11:29:46'),
(72, 12, 'ACC-00072', 'Available', 'Good', '2026-08-01 11:29:46'),
(73, 22, 'ACC-00073', 'Available', 'Good', '2026-08-01 11:29:46'),
(74, 7, 'ACC-00074', 'Available', 'Good', '2026-08-02 06:47:55');

-- --------------------------------------------------------

--
-- Table structure for table `bookinfo`
--

CREATE TABLE `bookinfo` (
  `book_id` int(11) NOT NULL,
  `isbn` varchar(13) NOT NULL,
  `title` varchar(255) NOT NULL,
  `publisher_id` int(11) DEFAULT NULL,
  `edition` varchar(50) DEFAULT NULL,
  `year_published` year(4) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `date_added` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bookinfo`
--

INSERT INTO `bookinfo` (`book_id`, `isbn`, `title`, `publisher_id`, `edition`, `year_published`, `price`, `date_added`) VALUES
(1, '9780061122415', 'The Notebook', 6, '1st Edition', '2008', 520.00, '2026-07-31 10:02:59'),
(2, '9780062073488', 'Gone Girl', 7, '1st Edition', '2012', 650.00, '2026-07-31 10:02:59'),
(3, '9780062316110', 'Sapiens: A Brief History of Humankind', 11, '1st Edition', '2015', 950.00, '2026-07-31 10:02:59'),
(4, '9780134685991', 'Calculus', 15, '9th Edition', '2020', 2150.00, '2026-07-31 10:02:59'),
(5, '9780134706054', 'Educational Psychology', 14, '14th Edition', '2018', 1650.00, '2026-07-31 10:02:59'),
(6, '9780135166307', 'Computer Networking: A Top-Down Approach', 14, '8th Edition', '2021', 2450.00, '2026-07-31 10:02:59'),
(7, '9780135191439', 'English Grammar in Use', 16, '5th Edition', '2019', 1200.00, '2026-07-31 10:02:59'),
(8, '9780135957059', 'Introduction to Java Programming', 14, '13th Edition', '2022', 2300.00, '2026-07-31 10:02:59'),
(9, '9780140449334', 'Meditations', 2, 'Revised Edition', '2006', 550.00, '2026-07-31 10:02:59'),
(10, '9780141439518', 'A Tale of Two Cities', 2, '2nd Edition', '2003', 599.00, '2026-07-31 10:02:59'),
(11, '9780143127741', 'Guns, Germs, and Steel', 13, '1st Edition', '2017', 850.00, '2026-07-31 10:02:59'),
(12, '9780197612132', 'Merriam-Webster\'s Collegiate Dictionary', 19, '11th Edition', '2020', 1100.00, '2026-07-31 10:02:59'),
(13, '9780307743657', 'The Girl with the Dragon Tattoo', 8, '1st Edition', '2008', 699.00, '2026-07-31 10:02:59'),
(14, '9780307743688', 'The Shining', 9, '2nd Edition', '2013', 750.00, '2026-07-31 10:02:59'),
(15, '9780316769488', 'The Hunger Games', 10, '1st Edition', '2008', 680.00, '2026-07-31 10:02:59'),
(16, '9780439139601', 'Harry Potter and the Goblet of Fire', 1, '1st Edition', '2000', 899.00, '2026-07-31 10:02:59'),
(17, '9780500296684', 'The Story of Art', 17, '16th Edition', '2020', 1850.00, '2026-07-31 10:02:59'),
(18, '9780545582889', 'The Hobbit', 5, '3rd Edition', '2012', 850.00, '2026-07-31 10:02:59'),
(19, '9780553382563', 'Dune', 4, 'Deluxe Edition', '2005', 999.00, '2026-07-31 10:02:59'),
(20, '9780743273565', 'The Great Gatsby', 3, '1st Edition', '2004', 499.00, '2026-07-31 10:02:59'),
(21, '9781292401981', 'Principles of Marketing', 14, '18th Edition', '2021', 1950.00, '2026-07-31 10:02:59'),
(22, '9781426222221', 'National Geographic Almanac 2024', 20, '2024 Edition', '2024', 900.00, '2026-07-31 10:02:59'),
(23, '9781501127625', 'Steve Jobs', 12, '1st Edition', '2015', 890.00, '2026-07-31 10:02:59'),
(24, '9781786571205', 'Lonely Planet Japan', 18, '17th Edition', '2023', 1300.00, '2026-07-31 10:02:59');

-- --------------------------------------------------------

--
-- Table structure for table `borrowtransaction`
--

CREATE TABLE `borrowtransaction` (
  `transaction_id` int(11) NOT NULL,
  `member_id` int(11) NOT NULL,
  `copy_id` int(11) NOT NULL,
  `issued_by` int(11) DEFAULT NULL,
  `borrow_date` date NOT NULL,
  `due_date` date NOT NULL,
  `return_date` date DEFAULT NULL,
  `received_by` int(11) DEFAULT NULL,
  `return_condition` enum('Good','Damaged','Lost') DEFAULT NULL,
  `transaction_status` enum('Borrowed','Returned') NOT NULL DEFAULT 'Borrowed'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `borrowtransaction`
--

INSERT INTO `borrowtransaction` (`transaction_id`, `member_id`, `copy_id`, `issued_by`, `borrow_date`, `due_date`, `return_date`, `received_by`, `return_condition`, `transaction_status`) VALUES
(1, 2, 6, NULL, '2026-07-31', '2026-08-02', '2026-07-31', NULL, 'Good', 'Returned'),
(2, 2, 7, NULL, '2026-07-31', '2026-08-02', '2026-07-31', NULL, 'Good', 'Returned'),
(3, 2, 11, NULL, '2026-07-31', '2026-08-02', '2026-07-31', NULL, 'Good', 'Returned'),
(4, 2, 6, NULL, '2026-07-31', '2026-08-02', '2026-07-31', NULL, 'Good', 'Returned'),
(5, 2, 7, NULL, '2026-07-31', '2026-08-02', '2026-07-31', NULL, 'Good', 'Returned'),
(6, 2, 17, NULL, '2026-07-26', '2026-07-28', '2026-07-31', NULL, 'Good', 'Returned'),
(7, 2, 6, NULL, '2026-08-01', '2026-08-03', '2026-08-02', NULL, 'Good', 'Returned'),
(8, 2, 31, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Good', 'Returned'),
(9, 2, 10, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Good', 'Returned'),
(10, 2, 21, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Good', 'Returned'),
(11, 2, 5, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Good', 'Returned'),
(12, 2, 2, NULL, '2026-07-31', '2026-08-01', '2026-08-02', NULL, 'Lost', 'Returned'),
(13, 2, 23, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Good', 'Returned'),
(14, 2, 6, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Damaged', 'Returned'),
(15, 2, 22, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Damaged', 'Returned'),
(16, 6, 17, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Damaged', 'Returned'),
(17, 6, 9, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Lost', 'Returned'),
(18, 6, 10, NULL, '2026-08-02', '2026-08-04', '2026-08-02', NULL, 'Damaged', 'Returned'),
(19, 6, 6, NULL, '2026-07-30', '2026-08-01', '2026-10-06', NULL, NULL, 'Returned'),
(20, 5, 31, NULL, '2026-08-02', '2026-08-04', NULL, NULL, NULL, 'Borrowed'),
(21, 7, 25, NULL, '2026-10-06', '2026-10-08', '2026-10-06', 10, 'Good', 'Returned'),
(22, 7, 25, NULL, '2026-10-06', '2026-10-08', '2026-10-06', 10, 'Good', 'Returned'),
(23, 7, 17, NULL, '2026-10-06', '2026-10-08', '2026-10-06', 10, 'Lost', 'Returned'),
(24, 7, 15, NULL, '2026-10-06', '2026-10-08', '2026-10-06', 10, 'Damaged', 'Returned');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`) VALUES
(10, 'Action & Adventure'),
(21, 'Art & Photography'),
(12, 'Biography'),
(18, 'Business & Economics'),
(16, 'Computer Science / Information Technology'),
(19, 'Education'),
(5, 'Fantasy'),
(1, 'Fiction'),
(24, 'General Knowledge'),
(2, 'Historical Fiction'),
(13, 'History'),
(9, 'Horror'),
(20, 'Language & Literature'),
(3, 'Literary Fiction'),
(17, 'Mathematics'),
(7, 'Mystery'),
(11, 'Non-Fiction'),
(14, 'Philosophy'),
(23, 'Reference'),
(6, 'Romance'),
(15, 'Science & Technology'),
(4, 'Science Fiction'),
(8, 'Thriller'),
(22, 'Travel');

-- --------------------------------------------------------

--
-- Table structure for table `loginlogs`
--

CREATE TABLE `loginlogs` (
  `login_log_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `status` varchar(30) DEFAULT NULL,
  `attempt_time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loginlogs`
--

INSERT INTO `loginlogs` (`login_log_id`, `user_id`, `username`, `status`, `attempt_time`) VALUES
(1, 7, 'kevinn', 'Success', '2026-10-06 12:21:10'),
(2, 7, 'kevinn', 'Failed', '2026-10-06 12:21:41'),
(3, 7, 'kevinn', 'Failed', '2026-10-06 12:21:44'),
(4, 7, 'kevinn', 'Failed', '2026-10-06 12:21:47'),
(5, 1, 'A_admin', 'Success', '2026-10-06 12:22:45'),
(6, 7, 'kevinn', 'Locked Out', '2026-10-06 12:23:13'),
(7, 1, 'A_admin', 'Success', '2026-10-06 12:23:20'),
(8, 7, 'kevinn', 'Success', '2026-10-06 12:23:55'),
(9, 5, 'kcer', 'Success', '2026-10-06 12:24:34'),
(10, 1, 'A_admin', 'Success', '2026-10-06 12:26:39'),
(11, 10, 'librarian', 'Success', '2026-10-06 12:34:49'),
(12, 10, 'librarian', 'Success', '2026-10-06 12:35:17'),
(13, 7, 'kevinn', 'Success', '2026-10-06 12:37:59'),
(14, 10, 'librarian', 'Success', '2026-10-06 12:39:53'),
(15, 10, 'librarian', 'Success', '2026-10-06 12:40:06'),
(16, 7, 'kevinn', 'Success', '2026-10-06 12:40:56'),
(17, 7, 'kevinn', 'Success', '2026-10-06 12:42:36'),
(18, 10, 'librarian', 'Success', '2026-10-06 12:43:00'),
(19, 7, 'kevinn', 'Success', '2026-10-06 12:43:48'),
(20, 10, 'librarian', 'Success', '2026-10-06 12:44:58'),
(21, 10, 'librarian', 'Success', '2026-10-06 12:45:10'),
(22, 7, 'kevinn', 'Success', '2026-10-06 12:46:12'),
(23, 1, 'A_admin', 'Success', '2026-10-06 12:47:08'),
(24, 10, 'librarian', 'Success', '2026-10-06 12:50:49'),
(25, 1, 'A_admin', 'Success', '2026-10-06 12:51:28'),
(26, 6, 'Tailor', 'Success', '2026-10-06 13:05:58'),
(27, 10, 'librarian', 'Success', '2026-10-07 14:40:27'),
(28, 10, 'librarian', 'Success', '2026-10-07 14:44:43'),
(29, 6, 'Tailor', 'Success', '2026-10-07 16:05:21'),
(30, 1, 'A_admin', 'Success', '2026-10-07 16:10:47'),
(31, 6, 'Tailor', 'Success', '2026-10-07 16:14:45'),
(32, 10, 'librarian', 'Success', '2026-10-07 16:15:09'),
(33, 10, 'librarian', 'Success', '2026-10-07 18:31:54'),
(34, 1, 'A_admin', 'Success', '2026-10-07 19:19:47'),
(35, 1, 'A_admin', 'Success', '2026-10-07 19:29:52'),
(36, 3, 'A_Librarian', 'Success', '2026-10-07 19:37:28'),
(37, 3, 'A_Librarian', 'Success', '2026-10-07 19:38:58'),
(38, 1, 'A_admin', 'Success', '2026-10-07 19:39:10');

-- --------------------------------------------------------

--
-- Table structure for table `lostdamagedbooks`
--

CREATE TABLE `lostdamagedbooks` (
  `incident_id` int(11) NOT NULL,
  `copy_id` int(11) NOT NULL,
  `transaction_id` int(11) DEFAULT NULL,
  `member_id` int(11) DEFAULT NULL,
  `incident_type` enum('Lost','Damaged') NOT NULL,
  `incident_date` date NOT NULL,
  `reported_by` int(11) DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `is_resolved` tinyint(1) NOT NULL DEFAULT 0,
  `resolved_date` date DEFAULT NULL,
  `date_recorded` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lostdamagedbooks`
--

INSERT INTO `lostdamagedbooks` (`incident_id`, `copy_id`, `transaction_id`, `member_id`, `incident_type`, `incident_date`, `reported_by`, `remarks`, `is_resolved`, `resolved_date`, `date_recorded`) VALUES
(1, 2, 12, 2, 'Lost', '2026-08-02', NULL, 'Imported from borrow history', 0, NULL, '2026-10-07 10:24:15'),
(2, 9, 17, 6, 'Lost', '2026-08-02', NULL, 'Imported from borrow history', 1, '2026-10-07', '2026-10-07 10:24:15'),
(3, 17, 23, 7, 'Lost', '2026-10-06', 10, 'Imported from borrow history', 0, NULL, '2026-10-07 10:24:15'),
(4, 15, 24, 7, 'Damaged', '2026-10-06', 10, 'Imported from borrow history', 0, NULL, '2026-10-07 10:24:15'),
(8, 6, 14, 2, 'Damaged', '2026-08-02', NULL, 'Imported from borrow history', 1, '2026-10-07', '2026-10-07 11:29:03'),
(9, 22, 15, 2, 'Damaged', '2026-08-02', NULL, 'Imported from borrow history', 0, NULL, '2026-10-07 11:29:03'),
(10, 10, 18, 6, 'Damaged', '2026-08-02', NULL, 'Imported from borrow history', 0, NULL, '2026-10-07 11:29:03');

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `member_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `member_type` enum('Student','Teacher','Staff') NOT NULL,
  `course` varchar(100) DEFAULT NULL,
  `year_level` int(11) DEFAULT NULL,
  `department` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`member_id`, `user_id`, `member_type`, `course`, `year_level`, `department`) VALUES
(2, 2, 'Student', 'BS Information Technology', 3, NULL),
(5, 5, 'Student', 'BS Information Technology', 3, NULL),
(6, 6, 'Student', 'BS Information Technology', 3, NULL),
(7, 7, 'Student', 'BS Information Technology', 1, NULL),
(8, 8, 'Student', 'BS Information Technology', 1, NULL),
(9, 9, 'Teacher', NULL, NULL, 'BS Information Technology'),
(10, 10, 'Staff', NULL, NULL, 'Juris Doctor');

-- --------------------------------------------------------

--
-- Table structure for table `old_account`
--

CREATE TABLE `old_account` (
  `account_id` int(11) NOT NULL,
  `user_id` varchar(20) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) NOT NULL,
  `suffix` varchar(20) DEFAULT NULL,
  `gender` varchar(20) NOT NULL,
  `birthdate` varchar(10) NOT NULL,
  `contact_num` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `account_type` enum('Student','Teacher','Librarian','Admin') NOT NULL DEFAULT 'Student',
  `date_registered` timestamp NOT NULL DEFAULT current_timestamp(),
  `account_status` varchar(50) DEFAULT NULL,
  `course` varchar(100) DEFAULT NULL,
  `year_level` int(11) DEFAULT NULL,
  `attempts` int(11) DEFAULT 3
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `old_account`
--

INSERT INTO `old_account` (`account_id`, `user_id`, `username`, `password`, `first_name`, `middle_name`, `last_name`, `suffix`, `gender`, `birthdate`, `contact_num`, `email`, `account_type`, `date_registered`, `account_status`, `course`, `year_level`, `attempts`) VALUES
(1, '000001', 'A_admin', '12345678', 'Alliyah', NULL, 'De Vera', NULL, 'Female', '2006-05-31', '09612345678', 'Alli@gmail.com', 'Admin', '2026-07-30 08:22:38', 'Active', 'BS Information Technology', 3, 3),
(2, '139524', 'sphciao', '12345678', 'Sophia Cassandra', 'Villacorte', 'Solis', NULL, 'Female', '2006-01-16', '09690141523', 'sphciao@gmail.com', 'Student', '2026-07-30 12:01:34', 'Active', 'BS Information Technology', 3, 3),
(3, '120824', 'A_Librarian', '12345678', 'Andrea', NULL, 'Para', NULL, 'Female', '2006-01-16', '09690141523', 'andreapara@gmail.com', 'Librarian', '2026-07-31 10:46:59', 'Active', 'BS Information Technology', 3, 3),
(5, '278024', 'kcer', '12345678', 'Kevin', NULL, 'Roque', NULL, 'Male', '2005-11-17', '09876475843', 'kev@gmail.com', 'Student', '2026-08-02 11:28:30', 'Active', 'BS Information Technology', 3, 3),
(6, '132724', 'Tailor', '12345678', 'Jonnidel', NULL, 'Reales', NULL, 'Male', '2004-07-06', '09603758429', 'jonnidel@gmail.com', 'Student', '2026-08-02 11:46:51', 'Active', 'BS Information Technology', 3, 3);

-- --------------------------------------------------------

--
-- Table structure for table `old_activitylogs`
--

CREATE TABLE `old_activitylogs` (
  `log_id` int(11) NOT NULL,
  `account_id` int(11) DEFAULT NULL,
  `action` varchar(100) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `data_time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `old_activitylogs`
--

INSERT INTO `old_activitylogs` (`log_id`, `account_id`, `action`, `description`, `data_time`) VALUES
(1, 1, 'Import Books', '24 book record(s) imported from Excel file.', '2026-07-31 18:02:59'),
(2, 1, 'Add Book', 'Added \'A Tale of Two Cities\' (ISBN 9780141439518)', '2026-07-31 18:03:23'),
(3, 1, 'Import Books', '24 book record(s) imported from Excel file.', '2026-08-01 19:28:08'),
(4, 3, 'Import Books', '24 book record(s) imported from Excel file.', '2026-08-01 19:29:46'),
(5, 1, 'Add Book', 'Added \'English Grammar in Use\' (ISBN 9780135191439)', '2026-08-02 14:47:55'),
(6, 3, 'Penalty Management', 'Marked transaction #6 penalty as Paid.', '2026-08-02 15:16:26'),
(7, 3, 'Verify Record', 'Verified transaction #13 as Good — no penalty', '2026-08-02 17:30:18'),
(8, 3, 'Verify Record', 'Verified transaction #14 as Damaged — penalty ₱520.00', '2026-08-02 17:31:46'),
(9, 3, 'Update Penalty', 'Updated transaction #14 — condition Damaged, amount ₱520.00, status Paid', '2026-08-02 18:20:40'),
(10, 3, 'Update Penalty', 'Updated transaction #14 — condition Damaged, amount ₱520.00, status Paid', '2026-08-02 18:20:56'),
(11, 3, 'Verify Record', 'Verified transaction #15 as Good — no penalty', '2026-08-02 18:37:09'),
(12, 3, 'Verify Record', 'Verified transaction #15 as Damaged — penalty ₱1,300.00', '2026-08-02 18:37:42'),
(13, 3, 'Verify Record', 'Verified transaction #12 as Lost — penalty ₱749.00', '2026-08-02 18:58:08'),
(14, 3, 'Verify Record', 'Verified transaction #16 as Damaged — penalty ₱2,150.00', '2026-08-02 19:51:05'),
(15, 3, 'Update Penalty', 'Updated transaction #16 — condition Damaged, amount ₱2,150.00, status Paid', '2026-08-02 19:54:40'),
(16, 3, 'Update Penalty', 'Updated transaction #16 — condition Damaged, amount ₱2,150.00, status Paid', '2026-08-02 19:56:40'),
(17, 3, 'Verify Record', 'Verified transaction #17 as Lost — penalty ₱750.00', '2026-08-02 20:07:42'),
(18, 3, 'Update Penalty', 'Updated transaction #17 — condition Lost, amount ₱750.00, status Unpaid', '2026-08-02 20:07:51'),
(19, 3, 'Update Penalty', 'Updated transaction #17 — condition Lost, amount ₱750.00, status Unpaid', '2026-08-02 20:07:55'),
(20, 3, 'Update Penalty', 'Updated transaction #17 — condition Lost, amount ₱750.00, status Paid', '2026-08-02 20:08:09'),
(21, 3, 'Verify Record', 'Verified transaction #18 as Damaged — penalty ₱680.00', '2026-08-02 20:44:23'),
(22, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Paid', '2026-08-02 20:44:46'),
(23, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Unpaid', '2026-08-02 20:45:28'),
(24, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Paid', '2026-08-02 20:46:10'),
(25, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Unpaid', '2026-08-02 20:46:40'),
(26, 3, 'Update Penalty', 'Updated transaction #6 — condition Good, amount ₱450.00, status Unpaid', '2026-08-02 20:48:58'),
(27, 3, 'Update Penalty', 'Updated transaction #18 — condition Damaged, amount ₱680.00, status Paid', '2026-08-02 22:30:42');

-- --------------------------------------------------------

--
-- Table structure for table `old_book`
--

CREATE TABLE `old_book` (
  `book_id` int(11) NOT NULL,
  `isbn` varchar(13) NOT NULL,
  `title` varchar(255) NOT NULL,
  `author` varchar(150) NOT NULL,
  `publisher` varchar(150) DEFAULT NULL,
  `category` varchar(100) DEFAULT NULL,
  `edition` varchar(50) DEFAULT NULL,
  `year_published` year(4) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `date_added` timestamp NOT NULL DEFAULT current_timestamp(),
  `copies` int(11) DEFAULT NULL,
  `book_status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `old_book`
--

INSERT INTO `old_book` (`book_id`, `isbn`, `title`, `author`, `publisher`, `category`, `edition`, `year_published`, `price`, `date_added`, `copies`, `book_status`) VALUES
(1, '9780439139601', 'Harry Potter and the Goblet of Fire', 'J.K. Rowling', 'Bloomsbury', 'Fiction', '1st Edition', '2000', 899.00, '2026-07-31 10:02:59', NULL, NULL),
(2, '9780141439518', 'A Tale of Two Cities', 'Charles Dickens', 'Penguin Classics', 'Historical Fiction', '2nd Edition', '2003', 599.00, '2026-07-31 10:02:59', NULL, NULL),
(3, '9780743273565', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Scribner', 'Literary Fiction', '1st Edition', '2004', 499.00, '2026-07-31 10:02:59', NULL, NULL),
(4, '9780553382563', 'Dune', 'Frank Herbert', 'Ace Books', 'Science Fiction', 'Deluxe Edition', '2005', 999.00, '2026-07-31 10:02:59', NULL, NULL),
(5, '9780545582889', 'The Hobbit', 'J.R.R. Tolkien', 'HarperCollins', 'Fantasy', '3rd Edition', '2012', 850.00, '2026-07-31 10:02:59', NULL, NULL),
(6, '9780061122415', 'The Notebook', 'Nicholas Sparks', 'Grand Central Publishing', 'Romance', '1st Edition', '2008', 520.00, '2026-07-31 10:02:59', NULL, NULL),
(7, '9780062073488', 'Gone Girl', 'Gillian Flynn', 'Crown Publishing', 'Mystery', '1st Edition', '2012', 650.00, '2026-07-31 10:02:59', NULL, NULL),
(8, '9780307743657', 'The Girl with the Dragon Tattoo', 'Stieg Larsson', 'Vintage Crime', 'Thriller', '1st Edition', '2008', 699.00, '2026-07-31 10:02:59', NULL, NULL),
(9, '9780307743688', 'The Shining', 'Stephen King', 'Anchor Books', 'Horror', '2nd Edition', '2013', 750.00, '2026-07-31 10:02:59', NULL, NULL),
(10, '9780316769488', 'The Hunger Games', 'Suzanne Collins', 'Scholastic Press', 'Action & Adventure', '1st Edition', '2008', 680.00, '2026-07-31 10:02:59', NULL, NULL),
(11, '9780062316110', 'Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 'Harper', 'Non-Fiction', '1st Edition', '2015', 950.00, '2026-07-31 10:02:59', NULL, NULL),
(12, '9781501127625', 'Steve Jobs', 'Walter Isaacson', 'Simon & Schuster', 'Biography', '1st Edition', '2015', 890.00, '2026-07-31 10:02:59', NULL, NULL),
(13, '9780143127741', 'Guns, Germs, and Steel', 'Jared Diamond', 'W.W. Norton', 'History', '1st Edition', '2017', 850.00, '2026-07-31 10:02:59', NULL, NULL),
(14, '9780140449334', 'Meditations', 'Marcus Aurelius', 'Penguin Classics', 'Philosophy', 'Revised Edition', '2006', 550.00, '2026-07-31 10:02:59', NULL, NULL),
(15, '9780135166307', 'Computer Networking: A Top-Down Approach', 'James F. Kurose', 'Pearson', 'Science & Technology', '8th Edition', '2021', 2450.00, '2026-07-31 10:02:59', NULL, NULL),
(16, '9780135957059', 'Introduction to Java Programming', 'Y. Daniel Liang', 'Pearson', 'Computer Science / Information Technology', '13th Edition', '2022', 2300.00, '2026-07-31 10:02:59', NULL, NULL),
(17, '9780134685991', 'Calculus', 'James Stewart', 'Cengage Learning', 'Mathematics', '9th Edition', '2020', 2150.00, '2026-07-31 10:02:59', NULL, NULL),
(18, '9781292401981', 'Principles of Marketing', 'Philip Kotler', 'Pearson', 'Business & Economics', '18th Edition', '2021', 1950.00, '2026-07-31 10:02:59', NULL, NULL),
(19, '9780134706054', 'Educational Psychology', 'Anita Woolfolk', 'Pearson', 'Education', '14th Edition', '2018', 1650.00, '2026-07-31 10:02:59', NULL, NULL),
(20, '9780135191439', 'English Grammar in Use', 'Raymond Murphy', 'Cambridge University Press', 'Language & Literature', '5th Edition', '2019', 1200.00, '2026-07-31 10:02:59', NULL, NULL),
(21, '9780500296684', 'The Story of Art', 'E.H. Gombrich', 'Phaidon Press', 'Art & Photography', '16th Edition', '2020', 1850.00, '2026-07-31 10:02:59', NULL, NULL),
(22, '9781786571205', 'Lonely Planet Japan', 'Lonely Planet', 'Lonely Planet', 'Travel', '17th Edition', '2023', 1300.00, '2026-07-31 10:02:59', NULL, NULL),
(23, '9780197612132', 'Merriam-Webster\'s Collegiate Dictionary', 'Merriam-Webster', 'Merriam-Webster', 'Reference', '11th Edition', '2020', 1100.00, '2026-07-31 10:02:59', NULL, NULL),
(24, '9781426222221', 'National Geographic Almanac 2024', 'National Geographic', 'National Geographic', 'General Knowledge', '2024 Edition', '2024', 900.00, '2026-07-31 10:02:59', NULL, NULL),
(25, '9780141439518', 'A Tale of Two Cities', 'Charles Dickens', 'Penguin Classics', 'Historical Fiction', '2nd Edition', '2003', 599.00, '2026-07-31 10:03:23', NULL, NULL),
(26, '9780439139601', 'Harry Potter and the Goblet of Fire', 'J.K. Rowling', 'Bloomsbury', 'Fiction', '1st Edition', '2000', 899.00, '2026-08-01 11:28:08', NULL, NULL),
(27, '9780141439518', 'A Tale of Two Cities', 'Charles Dickens', 'Penguin Classics', 'Historical Fiction', '2nd Edition', '2003', 599.00, '2026-08-01 11:28:08', NULL, NULL),
(28, '9780743273565', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Scribner', 'Literary Fiction', '1st Edition', '2004', 499.00, '2026-08-01 11:28:08', NULL, NULL),
(29, '9780553382563', 'Dune', 'Frank Herbert', 'Ace Books', 'Science Fiction', 'Deluxe Edition', '2005', 999.00, '2026-08-01 11:28:08', NULL, NULL),
(30, '9780545582889', 'The Hobbit', 'J.R.R. Tolkien', 'HarperCollins', 'Fantasy', '3rd Edition', '2012', 850.00, '2026-08-01 11:28:08', NULL, NULL),
(31, '9780061122415', 'The Notebook', 'Nicholas Sparks', 'Grand Central Publishing', 'Romance', '1st Edition', '2008', 520.00, '2026-08-01 11:28:08', NULL, NULL),
(32, '9780062073488', 'Gone Girl', 'Gillian Flynn', 'Crown Publishing', 'Mystery', '1st Edition', '2012', 650.00, '2026-08-01 11:28:08', NULL, NULL),
(33, '9780307743657', 'The Girl with the Dragon Tattoo', 'Stieg Larsson', 'Vintage Crime', 'Thriller', '1st Edition', '2008', 699.00, '2026-08-01 11:28:08', NULL, NULL),
(34, '9780307743688', 'The Shining', 'Stephen King', 'Anchor Books', 'Horror', '2nd Edition', '2013', 750.00, '2026-08-01 11:28:08', NULL, NULL),
(35, '9780316769488', 'The Hunger Games', 'Suzanne Collins', 'Scholastic Press', 'Action & Adventure', '1st Edition', '2008', 680.00, '2026-08-01 11:28:08', NULL, NULL),
(36, '9780062316110', 'Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 'Harper', 'Non-Fiction', '1st Edition', '2015', 950.00, '2026-08-01 11:28:08', NULL, NULL),
(37, '9781501127625', 'Steve Jobs', 'Walter Isaacson', 'Simon & Schuster', 'Biography', '1st Edition', '2015', 890.00, '2026-08-01 11:28:08', NULL, NULL),
(38, '9780143127741', 'Guns, Germs, and Steel', 'Jared Diamond', 'W.W. Norton', 'History', '1st Edition', '2017', 850.00, '2026-08-01 11:28:08', NULL, NULL),
(39, '9780140449334', 'Meditations', 'Marcus Aurelius', 'Penguin Classics', 'Philosophy', 'Revised Edition', '2006', 550.00, '2026-08-01 11:28:08', NULL, NULL),
(40, '9780135166307', 'Computer Networking: A Top-Down Approach', 'James F. Kurose', 'Pearson', 'Science & Technology', '8th Edition', '2021', 2450.00, '2026-08-01 11:28:08', NULL, NULL),
(41, '9780135957059', 'Introduction to Java Programming', 'Y. Daniel Liang', 'Pearson', 'Computer Science / Information Technology', '13th Edition', '2022', 2300.00, '2026-08-01 11:28:08', NULL, NULL),
(42, '9780134685991', 'Calculus', 'James Stewart', 'Cengage Learning', 'Mathematics', '9th Edition', '2020', 2150.00, '2026-08-01 11:28:08', NULL, NULL),
(43, '9781292401981', 'Principles of Marketing', 'Philip Kotler', 'Pearson', 'Business & Economics', '18th Edition', '2021', 1950.00, '2026-08-01 11:28:08', NULL, NULL),
(44, '9780134706054', 'Educational Psychology', 'Anita Woolfolk', 'Pearson', 'Education', '14th Edition', '2018', 1650.00, '2026-08-01 11:28:08', NULL, NULL),
(45, '9780135191439', 'English Grammar in Use', 'Raymond Murphy', 'Cambridge University Press', 'Language & Literature', '5th Edition', '2019', 1200.00, '2026-08-01 11:28:08', NULL, NULL),
(46, '9780500296684', 'The Story of Art', 'E.H. Gombrich', 'Phaidon Press', 'Art & Photography', '16th Edition', '2020', 1850.00, '2026-08-01 11:28:08', NULL, NULL),
(47, '9781786571205', 'Lonely Planet Japan', 'Lonely Planet', 'Lonely Planet', 'Travel', '17th Edition', '2023', 1300.00, '2026-08-01 11:28:08', NULL, NULL),
(48, '9780197612132', 'Merriam-Webster\'s Collegiate Dictionary', 'Merriam-Webster', 'Merriam-Webster', 'Reference', '11th Edition', '2020', 1100.00, '2026-08-01 11:28:08', NULL, NULL),
(49, '9781426222221', 'National Geographic Almanac 2024', 'National Geographic', 'National Geographic', 'General Knowledge', '2024 Edition', '2024', 900.00, '2026-08-01 11:28:08', NULL, NULL),
(50, '9780439139601', 'Harry Potter and the Goblet of Fire', 'J.K. Rowling', 'Bloomsbury', 'Fiction', '1st Edition', '2000', 899.00, '2026-08-01 11:29:46', NULL, NULL),
(51, '9780141439518', 'A Tale of Two Cities', 'Charles Dickens', 'Penguin Classics', 'Historical Fiction', '2nd Edition', '2003', 599.00, '2026-08-01 11:29:46', NULL, NULL),
(52, '9780743273565', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Scribner', 'Literary Fiction', '1st Edition', '2004', 499.00, '2026-08-01 11:29:46', NULL, NULL),
(53, '9780553382563', 'Dune', 'Frank Herbert', 'Ace Books', 'Science Fiction', 'Deluxe Edition', '2005', 999.00, '2026-08-01 11:29:46', NULL, NULL),
(54, '9780545582889', 'The Hobbit', 'J.R.R. Tolkien', 'HarperCollins', 'Fantasy', '3rd Edition', '2012', 850.00, '2026-08-01 11:29:46', NULL, NULL),
(55, '9780061122415', 'The Notebook', 'Nicholas Sparks', 'Grand Central Publishing', 'Romance', '1st Edition', '2008', 520.00, '2026-08-01 11:29:46', NULL, NULL),
(56, '9780062073488', 'Gone Girl', 'Gillian Flynn', 'Crown Publishing', 'Mystery', '1st Edition', '2012', 650.00, '2026-08-01 11:29:46', NULL, NULL),
(57, '9780307743657', 'The Girl with the Dragon Tattoo', 'Stieg Larsson', 'Vintage Crime', 'Thriller', '1st Edition', '2008', 699.00, '2026-08-01 11:29:46', NULL, NULL),
(58, '9780307743688', 'The Shining', 'Stephen King', 'Anchor Books', 'Horror', '2nd Edition', '2013', 750.00, '2026-08-01 11:29:46', NULL, NULL),
(59, '9780316769488', 'The Hunger Games', 'Suzanne Collins', 'Scholastic Press', 'Action & Adventure', '1st Edition', '2008', 680.00, '2026-08-01 11:29:46', NULL, NULL),
(60, '9780062316110', 'Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 'Harper', 'Non-Fiction', '1st Edition', '2015', 950.00, '2026-08-01 11:29:46', NULL, NULL),
(61, '9781501127625', 'Steve Jobs', 'Walter Isaacson', 'Simon & Schuster', 'Biography', '1st Edition', '2015', 890.00, '2026-08-01 11:29:46', NULL, NULL),
(62, '9780143127741', 'Guns, Germs, and Steel', 'Jared Diamond', 'W.W. Norton', 'History', '1st Edition', '2017', 850.00, '2026-08-01 11:29:46', NULL, NULL),
(63, '9780140449334', 'Meditations', 'Marcus Aurelius', 'Penguin Classics', 'Philosophy', 'Revised Edition', '2006', 550.00, '2026-08-01 11:29:46', NULL, NULL),
(64, '9780135166307', 'Computer Networking: A Top-Down Approach', 'James F. Kurose', 'Pearson', 'Science & Technology', '8th Edition', '2021', 2450.00, '2026-08-01 11:29:46', NULL, NULL),
(65, '9780135957059', 'Introduction to Java Programming', 'Y. Daniel Liang', 'Pearson', 'Computer Science / Information Technology', '13th Edition', '2022', 2300.00, '2026-08-01 11:29:46', NULL, NULL),
(66, '9780134685991', 'Calculus', 'James Stewart', 'Cengage Learning', 'Mathematics', '9th Edition', '2020', 2150.00, '2026-08-01 11:29:46', NULL, NULL),
(67, '9781292401981', 'Principles of Marketing', 'Philip Kotler', 'Pearson', 'Business & Economics', '18th Edition', '2021', 1950.00, '2026-08-01 11:29:46', NULL, NULL),
(68, '9780134706054', 'Educational Psychology', 'Anita Woolfolk', 'Pearson', 'Education', '14th Edition', '2018', 1650.00, '2026-08-01 11:29:46', NULL, NULL),
(69, '9780135191439', 'English Grammar in Use', 'Raymond Murphy', 'Cambridge University Press', 'Language & Literature', '5th Edition', '2019', 1200.00, '2026-08-01 11:29:46', NULL, NULL),
(70, '9780500296684', 'The Story of Art', 'E.H. Gombrich', 'Phaidon Press', 'Art & Photography', '16th Edition', '2020', 1850.00, '2026-08-01 11:29:46', NULL, NULL),
(71, '9781786571205', 'Lonely Planet Japan', 'Lonely Planet', 'Lonely Planet', 'Travel', '17th Edition', '2023', 1300.00, '2026-08-01 11:29:46', NULL, NULL),
(72, '9780197612132', 'Merriam-Webster\'s Collegiate Dictionary', 'Merriam-Webster', 'Merriam-Webster', 'Reference', '11th Edition', '2020', 1100.00, '2026-08-01 11:29:46', NULL, NULL),
(73, '9781426222221', 'National Geographic Almanac 2024', 'National Geographic', 'National Geographic', 'General Knowledge', '2024 Edition', '2024', 900.00, '2026-08-01 11:29:46', NULL, NULL),
(74, '9780135191439', 'English Grammar in Use', 'Raymond Murphy', 'Cambridge University Press', 'Language & Literature', '1st Edition', '2019', 1200.00, '2026-08-02 06:47:55', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `old_penalty`
--

CREATE TABLE `old_penalty` (
  `penalty_id` int(11) NOT NULL,
  `transaction_id` int(11) DEFAULT NULL,
  `penalty_amount` decimal(10,2) DEFAULT NULL,
  `penalty_status` varchar(50) DEFAULT NULL,
  `receipt_number` varchar(100) DEFAULT NULL,
  `verified_by` int(11) DEFAULT NULL,
  `verification_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `old_transaction`
--

CREATE TABLE `old_transaction` (
  `transaction_id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `borrow_date` date NOT NULL,
  `due_date` date NOT NULL,
  `return_date` date DEFAULT NULL,
  `condition_status` enum('Good','Damaged','Lost','Overdue') DEFAULT NULL,
  `penalty_amount` decimal(10,2) DEFAULT 0.00,
  `penalty_status` enum('None','Unpaid','Pending','Paid') DEFAULT 'None',
  `receipt_number` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `old_transaction`
--

INSERT INTO `old_transaction` (`transaction_id`, `account_id`, `book_id`, `borrow_date`, `due_date`, `return_date`, `condition_status`, `penalty_amount`, `penalty_status`, `receipt_number`) VALUES
(1, 2, 6, '2026-07-31', '2026-08-02', '2026-07-31', 'Good', 0.00, 'None', NULL),
(2, 2, 7, '2026-07-31', '2026-08-02', '2026-07-31', 'Good', 0.00, 'None', NULL),
(3, 2, 11, '2026-07-31', '2026-08-02', '2026-07-31', 'Good', 0.00, 'None', NULL),
(4, 2, 6, '2026-07-31', '2026-08-02', '2026-07-31', 'Good', 0.00, 'None', NULL),
(5, 2, 7, '2026-07-31', '2026-08-02', '2026-07-31', 'Good', 0.00, 'None', NULL),
(6, 2, 17, '2026-07-26', '2026-07-28', '2026-07-31', 'Good', 450.00, 'Unpaid', NULL),
(7, 2, 6, '2026-08-01', '2026-08-03', '2026-08-02', 'Good', 0.00, 'None', NULL),
(8, 2, 31, '2026-08-02', '2026-08-04', '2026-08-02', 'Good', 0.00, 'None', NULL),
(9, 2, 10, '2026-08-02', '2026-08-04', '2026-08-02', 'Good', 0.00, 'None', NULL),
(10, 2, 21, '2026-08-02', '2026-08-04', '2026-08-02', 'Good', 0.00, 'None', NULL),
(11, 2, 5, '2026-08-02', '2026-08-04', '2026-08-02', 'Good', 0.00, 'None', NULL),
(12, 2, 2, '2026-07-31', '2026-08-01', '2026-08-02', 'Lost', 749.00, 'Unpaid', NULL),
(13, 2, 23, '2026-08-02', '2026-08-04', '2026-08-02', 'Good', 0.00, 'None', NULL),
(14, 2, 6, '2026-08-02', '2026-08-04', '2026-08-02', 'Damaged', 520.00, 'Paid', '123456'),
(15, 2, 22, '2026-08-02', '2026-08-04', '2026-08-02', 'Damaged', 1300.00, 'Unpaid', NULL),
(16, 6, 17, '2026-08-02', '2026-08-04', '2026-08-02', 'Damaged', 2150.00, 'Paid', '234543'),
(17, 6, 9, '2026-08-02', '2026-08-04', '2026-08-02', 'Lost', 750.00, 'Paid', '278456'),
(18, 6, 10, '2026-08-02', '2026-08-04', '2026-08-02', 'Damaged', 680.00, 'Paid', '343453'),
(19, 6, 6, '2026-07-30', '2026-08-01', NULL, 'Good', 0.00, 'None', NULL),
(20, 5, 31, '2026-08-02', '2026-08-04', NULL, 'Good', 0.00, 'None', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `penalty`
--

CREATE TABLE `penalty` (
  `penalty_id` int(11) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `penalty_reason` set('Overdue','Damaged','Lost') NOT NULL,
  `days_overdue` int(11) NOT NULL DEFAULT 0,
  `penalty_amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `penalty_status` enum('Unpaid','Pending','Paid','Waived') NOT NULL DEFAULT 'Unpaid',
  `receipt_number` varchar(50) DEFAULT NULL,
  `verified_by` int(11) DEFAULT NULL,
  `verification_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `penalty`
--

INSERT INTO `penalty` (`penalty_id`, `transaction_id`, `penalty_reason`, `days_overdue`, `penalty_amount`, `penalty_status`, `receipt_number`, `verified_by`, `verification_date`) VALUES
(2, 12, 'Overdue,Lost', 1, 619.00, 'Unpaid', NULL, NULL, NULL),
(3, 14, 'Damaged', 0, 520.00, 'Paid', '123456', NULL, NULL),
(4, 15, 'Damaged', 0, 1300.00, 'Unpaid', NULL, NULL, NULL),
(5, 16, 'Damaged', 0, 2150.00, 'Paid', '234543', NULL, NULL),
(6, 17, 'Lost', 0, 750.00, 'Paid', '278456', NULL, NULL),
(7, 18, 'Damaged', 0, 680.00, 'Paid', '343453', NULL, NULL),
(8, 24, 'Damaged', 0, 2450.00, 'Paid', '123457', 10, '2026-10-06 12:45:48'),
(9, 23, 'Lost', 0, 2150.00, 'Paid', '236535', 10, '2026-10-06 12:46:02'),
(14, 19, 'Overdue', 66, 1320.00, 'Unpaid', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `publishers`
--

CREATE TABLE `publishers` (
  `publisher_id` int(11) NOT NULL,
  `publisher_name` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `publishers`
--

INSERT INTO `publishers` (`publisher_id`, `publisher_name`) VALUES
(4, 'Ace Books'),
(9, 'Anchor Books'),
(1, 'Bloomsbury'),
(16, 'Cambridge University Press'),
(15, 'Cengage Learning'),
(7, 'Crown Publishing'),
(6, 'Grand Central Publishing'),
(11, 'Harper'),
(5, 'HarperCollins'),
(18, 'Lonely Planet'),
(19, 'Merriam-Webster'),
(20, 'National Geographic'),
(14, 'Pearson'),
(2, 'Penguin Classics'),
(17, 'Phaidon Press'),
(10, 'Scholastic Press'),
(3, 'Scribner'),
(12, 'Simon & Schuster'),
(8, 'Vintage Crime'),
(13, 'W.W. Norton');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `school_id` varchar(20) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) NOT NULL,
  `suffix` varchar(20) DEFAULT NULL,
  `gender` varchar(20) NOT NULL,
  `contact_num` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `role` enum('Admin','Librarian','Member') NOT NULL DEFAULT 'Member',
  `account_status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `attempts` int(11) NOT NULL DEFAULT 3,
  `date_registered` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `school_id`, `username`, `password`, `first_name`, `middle_name`, `last_name`, `suffix`, `gender`, `contact_num`, `email`, `role`, `account_status`, `attempts`, `date_registered`) VALUES
(1, '000001', 'A_admin', 'PBKDF2$10000$NrTQBK4IdmIhaej6po29Hg==$38sfNoF9tGa8jlK9PvCHFk5D94wNDZ8TWsI1egt7b1U=', 'Alliyah', NULL, 'De Vera', NULL, 'Female', '09612345678', 'Alli@gmail.com', 'Admin', 'Active', 3, '2026-07-30 08:22:38'),
(2, '139524', 'sphciao', '12345678', 'Sophia Cassandra', 'Villacorte', 'Solis', NULL, 'Female', '09690141523', 'sphciao@gmail.com', 'Member', 'Active', 3, '2026-07-30 12:01:34'),
(3, '120824', 'A_Librarian', 'PBKDF2$10000$pIAY0fT28kClzK+Cr7bUmA==$NPqxGQ8A3k7QRunHNv8oP9AyIc4IGN7c5SxvwWRsxg4=', 'Andrea', NULL, 'Para', NULL, 'Female', '09690141523', 'andreapara@gmail.com', 'Librarian', 'Active', 3, '2026-07-31 10:46:59'),
(5, '278024', 'kcer', 'PBKDF2$10000$Vsjcxw11jWlIJZhLA1y/ww==$IMmw/9JxTv5bJrKtKjOwKPeoQHNP0H5UI1Ivqqf52UY=', 'Kevin', NULL, 'Roque', NULL, 'Male', '09876475843', 'kev@gmail.com', 'Member', 'Active', 3, '2026-08-02 11:28:30'),
(6, '132724', 'Tailor', 'PBKDF2$10000$kNzE2FjtrXh84HVUrNeyQg==$raLhUT/Q8tRISW00suyKMHB5zU9+2/h6r8VLkVNGouw=', 'Jonnidel', NULL, 'Reales', NULL, 'Male', '09603758429', 'jonnidel@gmail.com', 'Member', 'Active', 3, '2026-08-02 11:46:51'),
(7, '278624', 'kevinn', 'PBKDF2$10000$K7x+Ldwc6BQrT/wrfMNBtA==$hiD8QnjGz5FbFV1ZR7F8ad5wZaxr/G3+ODU7m3hgBXA=', 'kevinn', NULL, 'roque', NULL, 'Male', '12345678901', 'kevin@gmail.com', 'Member', 'Active', 3, '2026-10-06 04:21:02'),
(8, '123424', 'alliyah', 'PBKDF2$10000$kgMBpVl2lMx4T4A+yhWQIA==$q/zulRmS6yBgEMpzZH1P3MhXdR8fKaal4Tn8W7ACiNM=', 'alliyah', NULL, 'de vera', NULL, 'Female', '12345678901', 'alli@gmail.com', 'Member', 'Active', 3, '2026-10-06 04:29:15'),
(9, '123456', 'teacher', 'PBKDF2$10000$Us5P45760hl6qf2QgtksIA==$uxCVbC7GW3ipYTqDf/gIVRPTJmoD1YUpcEjKLYK7D7k=', 'teacher', NULL, 'teacher', NULL, 'Male', '12345678901', 'teacehr@gmail.com', 'Member', 'Active', 3, '2026-10-06 04:30:32'),
(10, '234567', 'librarian', 'PBKDF2$10000$ih9FzlV4hvpGlYD4kV42Rg==$eBxkl/TQgle/kfTFNhYAollzplVOAyjfqbpwp2Wb3Oo=', 'librarian', NULL, 'librarian', NULL, 'Female', '12345678901', 'librarian@gmail.com', 'Librarian', 'Active', 3, '2026-10-06 04:32:41');

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_bookcatalog`
-- (See below for the actual view)
--
CREATE TABLE `vw_bookcatalog` (
`book_id` int(11)
,`isbn` varchar(13)
,`title` varchar(255)
,`authors` mediumtext
,`categories` mediumtext
,`publisher_name` varchar(150)
,`edition` varchar(50)
,`year_published` year(4)
,`price` decimal(10,2)
,`total_copies` bigint(21)
,`available_copies` bigint(21)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `vw_borrowdetails`
-- (See below for the actual view)
--
CREATE TABLE `vw_borrowdetails` (
`transaction_id` int(11)
,`member_id` int(11)
,`user_id` int(11)
,`school_id` varchar(20)
,`username` varchar(50)
,`full_name` varchar(101)
,`member_type` enum('Student','Teacher','Staff')
,`copy_id` int(11)
,`accession_no` varchar(30)
,`book_id` int(11)
,`isbn` varchar(13)
,`title` varchar(255)
,`authors` mediumtext
,`borrow_date` date
,`due_date` date
,`return_date` date
,`return_condition` enum('Good','Damaged','Lost')
,`transaction_status` enum('Borrowed','Returned')
,`display_status` varchar(8)
,`penalty_amount` decimal(10,2)
,`penalty_status` varchar(7)
,`receipt_number` varchar(50)
);

-- --------------------------------------------------------

--
-- Structure for view `vw_bookcatalog`
--
DROP TABLE IF EXISTS `vw_bookcatalog`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_bookcatalog`  AS SELECT `b`.`book_id` AS `book_id`, `b`.`isbn` AS `isbn`, `b`.`title` AS `title`, (select group_concat(`a`.`author_name` order by `ba`.`author_order` ASC separator ' & ') from (`bookauthors` `ba` join `authors` `a` on(`a`.`author_id` = `ba`.`author_id`)) where `ba`.`book_id` = `b`.`book_id`) AS `authors`, (select group_concat(`c`.`category_name` order by `c`.`category_name` ASC separator ', ') from (`bookcategories` `bc` join `categories` `c` on(`c`.`category_id` = `bc`.`category_id`)) where `bc`.`book_id` = `b`.`book_id`) AS `categories`, `p`.`publisher_name` AS `publisher_name`, `b`.`edition` AS `edition`, `b`.`year_published` AS `year_published`, `b`.`price` AS `price`, (select count(0) from `bookcopies` `x` where `x`.`book_id` = `b`.`book_id` and `x`.`copy_status` not in ('Archived','Lost','Damaged') and !exists(select 1 from `lostdamagedbooks` `i` where `i`.`copy_id` = `x`.`copy_id` and `i`.`is_resolved` = 0 limit 1)) AS `total_copies`, (select count(0) from `bookcopies` `x` where `x`.`book_id` = `b`.`book_id` and `x`.`copy_status` = 'Available' and !exists(select 1 from `lostdamagedbooks` `i` where `i`.`copy_id` = `x`.`copy_id` and `i`.`is_resolved` = 0 limit 1)) AS `available_copies` FROM (`bookinfo` `b` left join `publishers` `p` on(`p`.`publisher_id` = `b`.`publisher_id`)) ;

-- --------------------------------------------------------

--
-- Structure for view `vw_borrowdetails`
--
DROP TABLE IF EXISTS `vw_borrowdetails`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_borrowdetails`  AS SELECT `t`.`transaction_id` AS `transaction_id`, `t`.`member_id` AS `member_id`, `u`.`user_id` AS `user_id`, `u`.`school_id` AS `school_id`, `u`.`username` AS `username`, concat(`u`.`first_name`,' ',`u`.`last_name`) AS `full_name`, `m`.`member_type` AS `member_type`, `t`.`copy_id` AS `copy_id`, `c`.`accession_no` AS `accession_no`, `b`.`book_id` AS `book_id`, `b`.`isbn` AS `isbn`, `b`.`title` AS `title`, (select group_concat(`a`.`author_name` order by `ba`.`author_order` ASC separator ' & ') from (`bookauthors` `ba` join `authors` `a` on(`a`.`author_id` = `ba`.`author_id`)) where `ba`.`book_id` = `b`.`book_id`) AS `authors`, `t`.`borrow_date` AS `borrow_date`, `t`.`due_date` AS `due_date`, `t`.`return_date` AS `return_date`, `t`.`return_condition` AS `return_condition`, `t`.`transaction_status` AS `transaction_status`, CASE WHEN `t`.`transaction_status` = 'Returned' THEN 'Returned' WHEN curdate() > `t`.`due_date` THEN 'Overdue' ELSE 'Borrowed' END AS `display_status`, ifnull(`pn`.`penalty_amount`,0) AS `penalty_amount`, ifnull(`pn`.`penalty_status`,'None') AS `penalty_status`, `pn`.`receipt_number` AS `receipt_number` FROM (((((`borrowtransaction` `t` join `members` `m` on(`m`.`member_id` = `t`.`member_id`)) join `users` `u` on(`u`.`user_id` = `m`.`user_id`)) join `bookcopies` `c` on(`c`.`copy_id` = `t`.`copy_id`)) join `bookinfo` `b` on(`b`.`book_id` = `c`.`book_id`)) left join `penalty` `pn` on(`pn`.`transaction_id` = `t`.`transaction_id`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `activitylogs`
--
ALTER TABLE `activitylogs`
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `idx_actlog_user` (`user_id`);

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`author_id`),
  ADD UNIQUE KEY `uq_author_name` (`author_name`);

--
-- Indexes for table `bookauthors`
--
ALTER TABLE `bookauthors`
  ADD PRIMARY KEY (`book_id`,`author_id`),
  ADD KEY `idx_bookauthors_author` (`author_id`);

--
-- Indexes for table `bookcategories`
--
ALTER TABLE `bookcategories`
  ADD PRIMARY KEY (`book_id`,`category_id`),
  ADD KEY `idx_bookcat_category` (`category_id`);

--
-- Indexes for table `bookcopies`
--
ALTER TABLE `bookcopies`
  ADD PRIMARY KEY (`copy_id`),
  ADD UNIQUE KEY `uq_copies_accession` (`accession_no`),
  ADD KEY `idx_copies_book` (`book_id`);

--
-- Indexes for table `bookinfo`
--
ALTER TABLE `bookinfo`
  ADD PRIMARY KEY (`book_id`),
  ADD UNIQUE KEY `uq_bookinfo_isbn` (`isbn`),
  ADD KEY `idx_bookinfo_title` (`title`),
  ADD KEY `fk_bookinfo_publisher` (`publisher_id`);

--
-- Indexes for table `borrowtransaction`
--
ALTER TABLE `borrowtransaction`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `idx_bt_member` (`member_id`),
  ADD KEY `idx_bt_copy` (`copy_id`),
  ADD KEY `idx_bt_status` (`transaction_status`,`due_date`),
  ADD KEY `fk_bt_issued` (`issued_by`),
  ADD KEY `fk_bt_recv` (`received_by`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`),
  ADD UNIQUE KEY `uq_category_name` (`category_name`);

--
-- Indexes for table `loginlogs`
--
ALTER TABLE `loginlogs`
  ADD PRIMARY KEY (`login_log_id`),
  ADD KEY `idx_loginlog_user` (`user_id`);

--
-- Indexes for table `lostdamagedbooks`
--
ALTER TABLE `lostdamagedbooks`
  ADD PRIMARY KEY (`incident_id`),
  ADD KEY `idx_ld_copy` (`copy_id`),
  ADD KEY `idx_ld_tx` (`transaction_id`),
  ADD KEY `idx_ld_date` (`incident_date`),
  ADD KEY `fk_ld_member` (`member_id`),
  ADD KEY `fk_ld_user` (`reported_by`);

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`member_id`),
  ADD UNIQUE KEY `uq_members_user` (`user_id`);

--
-- Indexes for table `old_account`
--
ALTER TABLE `old_account`
  ADD PRIMARY KEY (`account_id`),
  ADD UNIQUE KEY `user_id` (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `old_activitylogs`
--
ALTER TABLE `old_activitylogs`
  ADD PRIMARY KEY (`log_id`);

--
-- Indexes for table `old_book`
--
ALTER TABLE `old_book`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `old_penalty`
--
ALTER TABLE `old_penalty`
  ADD PRIMARY KEY (`penalty_id`);

--
-- Indexes for table `old_transaction`
--
ALTER TABLE `old_transaction`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `account_id` (`account_id`),
  ADD KEY `book_id` (`book_id`);

--
-- Indexes for table `penalty`
--
ALTER TABLE `penalty`
  ADD PRIMARY KEY (`penalty_id`),
  ADD UNIQUE KEY `uq_penalty_transaction` (`transaction_id`),
  ADD KEY `fk_penalty_verifier` (`verified_by`);

--
-- Indexes for table `publishers`
--
ALTER TABLE `publishers`
  ADD PRIMARY KEY (`publisher_id`),
  ADD UNIQUE KEY `uq_publisher_name` (`publisher_name`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `uq_users_school_id` (`school_id`),
  ADD UNIQUE KEY `uq_users_username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `activitylogs`
--
ALTER TABLE `activitylogs`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=86;

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `author_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `bookcopies`
--
ALTER TABLE `bookcopies`
  MODIFY `copy_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=75;

--
-- AUTO_INCREMENT for table `bookinfo`
--
ALTER TABLE `bookinfo`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `borrowtransaction`
--
ALTER TABLE `borrowtransaction`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `loginlogs`
--
ALTER TABLE `loginlogs`
  MODIFY `login_log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `lostdamagedbooks`
--
ALTER TABLE `lostdamagedbooks`
  MODIFY `incident_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `members`
--
ALTER TABLE `members`
  MODIFY `member_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `old_account`
--
ALTER TABLE `old_account`
  MODIFY `account_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `old_activitylogs`
--
ALTER TABLE `old_activitylogs`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `old_book`
--
ALTER TABLE `old_book`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=75;

--
-- AUTO_INCREMENT for table `old_penalty`
--
ALTER TABLE `old_penalty`
  MODIFY `penalty_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `old_transaction`
--
ALTER TABLE `old_transaction`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `penalty`
--
ALTER TABLE `penalty`
  MODIFY `penalty_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `publishers`
--
ALTER TABLE `publishers`
  MODIFY `publisher_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `activitylogs`
--
ALTER TABLE `activitylogs`
  ADD CONSTRAINT `fk_actlog_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE SET NULL;

--
-- Constraints for table `bookauthors`
--
ALTER TABLE `bookauthors`
  ADD CONSTRAINT `fk_ba_author` FOREIGN KEY (`author_id`) REFERENCES `authors` (`author_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ba_book` FOREIGN KEY (`book_id`) REFERENCES `bookinfo` (`book_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `bookcategories`
--
ALTER TABLE `bookcategories`
  ADD CONSTRAINT `fk_bc_book` FOREIGN KEY (`book_id`) REFERENCES `bookinfo` (`book_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bc_category` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `bookcopies`
--
ALTER TABLE `bookcopies`
  ADD CONSTRAINT `fk_copies_book` FOREIGN KEY (`book_id`) REFERENCES `bookinfo` (`book_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `bookinfo`
--
ALTER TABLE `bookinfo`
  ADD CONSTRAINT `fk_bookinfo_publisher` FOREIGN KEY (`publisher_id`) REFERENCES `publishers` (`publisher_id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `borrowtransaction`
--
ALTER TABLE `borrowtransaction`
  ADD CONSTRAINT `fk_bt_copy` FOREIGN KEY (`copy_id`) REFERENCES `bookcopies` (`copy_id`),
  ADD CONSTRAINT `fk_bt_issued` FOREIGN KEY (`issued_by`) REFERENCES `users` (`user_id`) ON DELETE SET NULL,
  ADD CONSTRAINT `fk_bt_member` FOREIGN KEY (`member_id`) REFERENCES `members` (`member_id`),
  ADD CONSTRAINT `fk_bt_recv` FOREIGN KEY (`received_by`) REFERENCES `users` (`user_id`) ON DELETE SET NULL;

--
-- Constraints for table `loginlogs`
--
ALTER TABLE `loginlogs`
  ADD CONSTRAINT `fk_loginlog_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE SET NULL;

--
-- Constraints for table `lostdamagedbooks`
--
ALTER TABLE `lostdamagedbooks`
  ADD CONSTRAINT `fk_ld_copy` FOREIGN KEY (`copy_id`) REFERENCES `bookcopies` (`copy_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ld_member` FOREIGN KEY (`member_id`) REFERENCES `members` (`member_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ld_tx` FOREIGN KEY (`transaction_id`) REFERENCES `borrowtransaction` (`transaction_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ld_user` FOREIGN KEY (`reported_by`) REFERENCES `users` (`user_id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `members`
--
ALTER TABLE `members`
  ADD CONSTRAINT `fk_members_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `old_transaction`
--
ALTER TABLE `old_transaction`
  ADD CONSTRAINT `old_transaction_ibfk_1` FOREIGN KEY (`account_id`) REFERENCES `old_account` (`account_id`),
  ADD CONSTRAINT `old_transaction_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `old_book` (`book_id`);

--
-- Constraints for table `penalty`
--
ALTER TABLE `penalty`
  ADD CONSTRAINT `fk_penalty_tx` FOREIGN KEY (`transaction_id`) REFERENCES `borrowtransaction` (`transaction_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_penalty_verifier` FOREIGN KEY (`verified_by`) REFERENCES `users` (`user_id`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
