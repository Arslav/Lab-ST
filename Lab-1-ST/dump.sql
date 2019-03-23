-- phpMyAdmin SQL Dump
-- version 4.7.0-rc1
-- https://www.phpmyadmin.net/
--
-- Хост: mysql6001.site4now.net
-- Время создания: Мар 23 2019 г., 13:39
-- Версия сервера: 5.6.26-log
-- Версия PHP: 7.0.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `db_a46ae1_arslav`
--
CREATE DATABASE IF NOT EXISTS `db_a46ae1_arslav` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `db_a46ae1_arslav`;

-- --------------------------------------------------------

--
-- Структура таблицы `account`
--

CREATE TABLE `account` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Счет';

--
-- Очистить таблицу перед добавлением данных `account`
--

TRUNCATE TABLE `account`;
--
-- Дамп данных таблицы `account`
--

INSERT INTO `account` (`id`, `client_id`) VALUES
(10, 1),
(11, 1),
(15, 1),
(12, 2),
(14, 3),
(18, 7);

-- --------------------------------------------------------

--
-- Структура таблицы `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `name` longtext NOT NULL COMMENT 'ФИО',
  `age` int(11) NOT NULL,
  `work` longtext NOT NULL COMMENT 'место раборы'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Очистить таблицу перед добавлением данных `client`
--

TRUNCATE TABLE `client`;
--
-- Дамп данных таблицы `client`
--

INSERT INTO `client` (`id`, `name`, `age`, `work`) VALUES
(1, 'Петров Сергей Иванович', 24, 'УМПО'),
(2, 'Голицын Владимир Евгеньевич', 17, 'Гидравлика'),
(3, 'Сергеев Олег Артурович', 35, 'БЭТО'),
(7, 'Иванов Владимир Иванович', 32, 'УМПО');

-- --------------------------------------------------------

--
-- Структура таблицы `history`
--

CREATE TABLE `history` (
  `id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `sum` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Очистить таблицу перед добавлением данных `history`
--

TRUNCATE TABLE `history`;
--
-- Дамп данных таблицы `history`
--

INSERT INTO `history` (`id`, `account_id`, `type`, `sum`) VALUES
(1, 10, 0, 200),
(2, 10, 1, 20),
(3, 11, 0, 300),
(4, 12, 0, 180),
(5, 12, 1, 60),
(8, 14, 0, 215.5),
(9, 14, 1, 32.12),
(12, 10, 0, 234),
(17, 15, 0, 24),
(19, 18, 0, 180),
(20, 18, 1, 45);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`id`),
  ADD KEY `client_fk_1_idx` (`client_id`);

--
-- Индексы таблицы `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `history`
--
ALTER TABLE `history`
  ADD PRIMARY KEY (`id`),
  ADD KEY `acount_fk_1_idx` (`account_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `account`
--
ALTER TABLE `account`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT для таблицы `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT для таблицы `history`
--
ALTER TABLE `history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `client_fk_1` FOREIGN KEY (`client_id`) REFERENCES `client` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ограничения внешнего ключа таблицы `history`
--
ALTER TABLE `history`
  ADD CONSTRAINT `acount_fk_1` FOREIGN KEY (`account_id`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
