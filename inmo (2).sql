-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-04-2020 a las 22:47:43
-- Versión del servidor: 10.3.16-MariaDB
-- Versión de PHP: 7.3.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `inmo`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contratos`
--

CREATE TABLE `contratos` (
  `id` int(11) NOT NULL,
  `inmuebleId` int(11) NOT NULL,
  `inquilinoId` int(11) NOT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_fin` date NOT NULL,
  `monto` double(10,2) DEFAULT NULL,
  `nombre_garante` varchar(50) NOT NULL,
  `dni_garante` varchar(50) NOT NULL,
  `telefono_garante` varchar(50) NOT NULL,
  `mail_garante` varchar(50) NOT NULL,
  `estado` enum('normal','rescindido') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `contratos`
--

INSERT INTO `contratos` (`id`, `inmuebleId`, `inquilinoId`, `fecha_inicio`, `fecha_fin`, `monto`, `nombre_garante`, `dni_garante`, `telefono_garante`, `mail_garante`, `estado`) VALUES
(26, 1, 4, '2020-03-31', '2020-04-30', 100.00, 'no', 'no', 'no', 'no', 'rescindido'),
(27, 1, 4, '2020-03-31', '2020-04-04', 10.00, 'no', 'no', 'no', 'no', 'rescindido'),
(28, 1, 4, '2020-03-31', '2020-04-01', 10.00, 'pojkop', 'opjop', 'pijopo', 'iopju', 'rescindido'),
(29, 2, 4, '2020-05-01', '2020-04-01', 20.00, 'no', 'no', 'no', 'no', 'rescindido'),
(30, 1, 4, '2020-03-31', '2020-04-01', 100.00, 'no', 'no', 'no', 'no', 'rescindido'),
(31, 1, 4, '2021-03-31', '2020-04-01', 100.00, 'no', 'no', 'no', 'no', 'rescindido'),
(32, 3, 4, '2020-07-01', '2020-04-01', 50000.00, 'a', 'no', '3', 'wedewfd', 'rescindido');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmuebles`
--

CREATE TABLE `inmuebles` (
  `id` int(11) NOT NULL,
  `propietarioId` int(11) NOT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  `ambientes` int(11) DEFAULT NULL,
  `uso` enum('comercial',' residencial') DEFAULT NULL,
  `tipo` enum('deposito','casa','departamento') DEFAULT NULL,
  `precio` double(10,2) NOT NULL,
  `disponible` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `inmuebles`
--

INSERT INTO `inmuebles` (`id`, `propietarioId`, `direccion`, `ambientes`, `uso`, `tipo`, `precio`, `disponible`) VALUES
(1, 1, 'Barrio Lince Mza 22, 19', 6, '', 'casa', 20000.00, 0),
(2, 1, 'Los aromos', 1, 'comercial', 'deposito', 20.00, 0),
(3, 2, 'El Horbero', 3, 'comercial', 'departamento', 50000.00, 0),
(4, 4, 'San Luis 23', 6, ' residencial', 'casa', 20.00, 1),
(5, 1, 'Barrio Lince Mza 22, 19', 2, '', 'casa', 10.00, 1),
(6, 1, 'Barrio Lince Mza 22\r\n19', 2, 'comercial', 'casa', 10.00, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilinos`
--

CREATE TABLE `inquilinos` (
  `id` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  `dni` varchar(45) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `lugar_trabajo` varchar(45) DEFAULT NULL,
  `estado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `inquilinos`
--

INSERT INTO `inquilinos` (`id`, `nombre`, `apellido`, `dni`, `telefono`, `email`, `lugar_trabajo`, `estado`) VALUES
(4, 'Perseo', 'Lucero', 'dniPerseo', 'telefonoPerseo', 'perseo@mail.com', 'San Luis', 'activo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pagos`
--

CREATE TABLE `pagos` (
  `id` int(11) NOT NULL,
  `contratoId` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `fechaVencimiento` date NOT NULL,
  `fechaPago` date NOT NULL,
  `importe` decimal(10,2) NOT NULL,
  `estado` enum('pagado','pendiente','rescindido') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `pagos`
--

INSERT INTO `pagos` (`id`, `contratoId`, `numero`, `fechaVencimiento`, `fechaPago`, `importe`, `estado`) VALUES
(53, 26, 1, '2020-03-31', '2020-04-01', '100.00', 'pagado'),
(54, 27, 1, '2020-03-31', '2020-04-01', '10.00', 'pagado'),
(55, 28, 1, '2020-03-31', '2020-04-01', '10.00', 'pagado'),
(56, 29, 1, '2020-05-01', '0000-00-00', '20.00', 'pendiente'),
(57, 30, 1, '2020-03-31', '2020-04-01', '100.00', 'pagado'),
(58, 31, 1, '2021-03-31', '0000-00-00', '100.00', 'pendiente'),
(59, 32, 1, '2020-07-01', '0000-00-00', '50000.00', 'pendiente'),
(60, 32, 2, '2020-08-01', '0000-00-00', '50000.00', 'pendiente'),
(61, 32, 3, '2020-09-01', '0000-00-00', '50000.00', 'pendiente'),
(62, 32, 4, '2020-10-01', '0000-00-00', '50000.00', 'pendiente'),
(63, 32, 5, '2020-11-01', '0000-00-00', '50000.00', 'pendiente'),
(64, 32, 6, '2020-12-01', '0000-00-00', '50000.00', 'pendiente'),
(65, 32, 7, '2021-01-01', '0000-00-00', '50000.00', 'pendiente'),
(66, 32, 8, '2021-02-01', '0000-00-00', '50000.00', 'pendiente'),
(67, 32, 9, '2021-03-01', '0000-00-00', '50000.00', 'pendiente');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietarios`
--

CREATE TABLE `propietarios` (
  `id` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `apellido` varchar(45) DEFAULT NULL,
  `dni` varchar(50) NOT NULL,
  `email` varchar(45) NOT NULL,
  `telefono` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `propietarios`
--

INSERT INTO `propietarios` (`id`, `nombre`, `apellido`, `dni`, `email`, `telefono`) VALUES
(1, 'Anahi', 'Ramos', '31518239', 'ana@mail', '2664'),
(2, 'Pedro', 'Lucero', '29887502', 'pedro@mail.com', '565685'),
(3, 'Maximo', 'Lucero', '46807127', 'maximo@gmail.com', '001274'),
(4, 'Silvia Mable', 'Torres', '16066706', 'silvia@mail.com', '4457409');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contratos`
--
ALTER TABLE `contratos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `inmuebleId` (`inmuebleId`),
  ADD KEY `inquilinoId` (`inquilinoId`);

--
-- Indices de la tabla `inmuebles`
--
ALTER TABLE `inmuebles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `propietarioId` (`propietarioId`);

--
-- Indices de la tabla `inquilinos`
--
ALTER TABLE `inquilinos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `contratoId` (`contratoId`);

--
-- Indices de la tabla `propietarios`
--
ALTER TABLE `propietarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contratos`
--
ALTER TABLE `contratos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT de la tabla `inmuebles`
--
ALTER TABLE `inmuebles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `inquilinos`
--
ALTER TABLE `inquilinos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `pagos`
--
ALTER TABLE `pagos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT de la tabla `propietarios`
--
ALTER TABLE `propietarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contratos`
--
ALTER TABLE `contratos`
  ADD CONSTRAINT `contratos_ibfk_1` FOREIGN KEY (`inmuebleId`) REFERENCES `inmuebles` (`id`),
  ADD CONSTRAINT `contratos_ibfk_2` FOREIGN KEY (`inquilinoId`) REFERENCES `inquilinos` (`id`);

--
-- Filtros para la tabla `inmuebles`
--
ALTER TABLE `inmuebles`
  ADD CONSTRAINT `inmuebles_ibfk_1` FOREIGN KEY (`propietarioId`) REFERENCES `propietarios` (`id`);

--
-- Filtros para la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD CONSTRAINT `pagos_ibfk_1` FOREIGN KEY (`contratoId`) REFERENCES `contratos` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
