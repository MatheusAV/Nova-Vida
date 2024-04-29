CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Professores` (
    `ProfessorId` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Data de Contratação` date NOT NULL,
    CONSTRAINT `PK_Professores` PRIMARY KEY (`ProfessorId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Alunos` (
    `AlunoId` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Valor da Mensalidade` decimal(18,2) NOT NULL,
    `Data de Vencimento` date NOT NULL,
    `ProfessorId` int NOT NULL,
    CONSTRAINT `PK_Alunos` PRIMARY KEY (`AlunoId`),
    CONSTRAINT `FK_Professor_Aluno` FOREIGN KEY (`ProfessorId`) REFERENCES `Professores` (`ProfessorId`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Alunos_ProfessorId` ON `Alunos` (`ProfessorId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231114163726_Init', '6.0.24');

COMMIT;

