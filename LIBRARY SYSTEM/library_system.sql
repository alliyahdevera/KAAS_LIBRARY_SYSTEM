-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 02, 2026 at 04:41 PM
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
-- Table structure for table `tblactivitylogs`
--

CREATE TABLE `tblactivitylogs` (
  `log_id` int(11) NOT NULL,
  `account_id` int(11) DEFAULT NULL,
  `action` varchar(100) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `data_time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblactivitylogs`
--

INSERT INTO `tblactivitylogs` (`log_id`, `account_id`, `action`, `description`, `data_time`) VALUES
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
-- Table structure for table `tblpenalty`
--

CREATE TABLE `tblpenalty` (
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
-- Table structure for table `tbl_account`
--

CREATE TABLE `tbl_account` (
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
-- Dumping data for table `tbl_account`
--

INSERT INTO `tbl_account` (`account_id`, `user_id`, `username`, `password`, `first_name`, `middle_name`, `last_name`, `suffix`, `gender`, `birthdate`, `contact_num`, `email`, `account_type`, `date_registered`, `account_status`, `course`, `year_level`, `attempts`) VALUES
(1, '000001', 'A_admin', '12345678', 'Alliyah', NULL, 'De Vera', NULL, 'Female', '2006-05-31', '09612345678', 'Alli@gmail.com', 'Admin', '2026-07-30 08:22:38', 'Active', 'BS Information Technology', 3, 3),
(2, '139524', 'sphciao', '12345678', 'Sophia Cassandra', 'Villacorte', 'Solis', NULL, 'Female', '2006-01-16', '09690141523', 'sphciao@gmail.com', 'Student', '2026-07-30 12:01:34', 'Active', 'BS Information Technology', 3, 3),
(3, '120824', 'A_Librarian', '12345678', 'Andrea', NULL, 'Para', NULL, 'Female', '2006-01-16', '09690141523', 'andreapara@gmail.com', 'Librarian', '2026-07-31 10:46:59', 'Active', 'BS Information Technology', 3, 3),
(5, '278024', 'kcer', '12345678', 'Kevin', NULL, 'Roque', NULL, 'Male', '2005-11-17', '09876475843', 'kev@gmail.com', 'Student', '2026-08-02 11:28:30', 'Active', 'BS Information Technology', 3, 3),
(6, '132724', 'Tailor', '12345678', 'Jonnidel', NULL, 'Reales', NULL, 'Male', '2004-07-06', '09603758429', 'jonnidel@gmail.com', 'Student', '2026-08-02 11:46:51', 'Active', 'BS Information Technology', 3, 3);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_book`
--

CREATE TABLE `tbl_book` (
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
-- Dumping data for table `tbl_book`
--

INSERT INTO `tbl_book` (`book_id`, `isbn`, `title`, `author`, `publisher`, `category`, `edition`, `year_published`, `price`, `date_added`, `copies`, `book_status`) VALUES
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
-- Table structure for table `tbl_transaction`
--

CREATE TABLE `tbl_transaction` (
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
-- Dumping data for table `tbl_transaction`
--

INSERT INTO `tbl_transaction` (`transaction_id`, `account_id`, `book_id`, `borrow_date`, `due_date`, `return_date`, `condition_status`, `penalty_amount`, `penalty_status`, `receipt_number`) VALUES
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

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblactivitylogs`
--
ALTER TABLE `tblactivitylogs`
  ADD PRIMARY KEY (`log_id`);

--
-- Indexes for table `tblpenalty`
--
ALTER TABLE `tblpenalty`
  ADD PRIMARY KEY (`penalty_id`);

--
-- Indexes for table `tbl_account`
--
ALTER TABLE `tbl_account`
  ADD PRIMARY KEY (`account_id`),
  ADD UNIQUE KEY `user_id` (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `tbl_book`
--
ALTER TABLE `tbl_book`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `tbl_transaction`
--
ALTER TABLE `tbl_transaction`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `account_id` (`account_id`),
  ADD KEY `book_id` (`book_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblactivitylogs`
--
ALTER TABLE `tblactivitylogs`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `tblpenalty`
--
ALTER TABLE `tblpenalty`
  MODIFY `penalty_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_account`
--
ALTER TABLE `tbl_account`
  MODIFY `account_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `tbl_book`
--
ALTER TABLE `tbl_book`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=75;

--
-- AUTO_INCREMENT for table `tbl_transaction`
--
ALTER TABLE `tbl_transaction`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_transaction`
--
ALTER TABLE `tbl_transaction`
  ADD CONSTRAINT `tbl_transaction_ibfk_1` FOREIGN KEY (`account_id`) REFERENCES `tbl_account` (`account_id`),
  ADD CONSTRAINT `tbl_transaction_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `tbl_book` (`book_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
