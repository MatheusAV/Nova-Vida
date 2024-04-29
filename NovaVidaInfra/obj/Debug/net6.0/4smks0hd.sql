CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Alunos` (
    `AlunoId` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `ValorMensalidade` decimal(18,2) NOT NULL,
    `DataVencimento` date NOT NULL,
    `IdProfessor` int NOT NULL,
    CONSTRAINT `PK_Alunos` PRIMARY KEY (`AlunoId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Professores` (
    `ProfessorId` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `DataContratacao` date NOT NULL,
    `Departamento` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Materia` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Professores` PRIMARY KEY (`ProfessorId`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231115130408_Init', '6.0.24');

COMMIT;

