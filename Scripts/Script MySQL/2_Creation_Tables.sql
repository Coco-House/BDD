USE `projet`;

CREATE TABLE `projet`.`fournisseur`
(
	`codeF` VARCHAR(10) NOT NULL,
	`nomF` VARCHAR(20) NOT NULL,
	`telF` INT NULL,
	PRIMARY KEY (`codeF`)
);

CREATE TABLE `projet`.`produit`
(
	`nomP` VARCHAR(20) NOT NULL,
    `categorieP` VARCHAR(20) NOT NULL,
	`quantite` INT NULL,
    `stockActuel` INT NULL,
    `stockMin` INT NULL,
    `stockMax` INT NULL,
    `codeF` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`nomP`),
    FOREIGN KEY (`codeF`) REFERENCES `projet`.`fournisseur`(`codeF`)
);

CREATE TABLE `projet`.`client`
(
	`idC` INT NOT NULL,
	`nomC` VARCHAR(20) NOT NULL,
	`telC` INT NULL,
	PRIMARY KEY (`idC`)
);

CREATE TABLE `projet`.`cdr`
(
	`idCdR` INT NOT NULL,
    `cook` INT NOT NULL,
    `idC` INT NOT NULL,
	PRIMARY KEY (`idCdR`),
    FOREIGN KEY (`idC`) REFERENCES `projet`.`client`(`idC`)
);

CREATE TABLE `projet`.`recette`
(
	`idR` INT NOT NULL,
	`nomR` VARCHAR(20) NOT NULL,
    `listeIngredients` VARCHAR(100) NOT NULL,
    `descriptionR` VARCHAR(100) NOT NULL,
	`prixR` INT NULL,
    `remunerationCuisinier` INT NULL,
    `idCdR` INT NOT NULL,
	PRIMARY KEY (`idR`),
    FOREIGN KEY (`idCdR`) REFERENCES `projet`.`cdr`(`idCdR`)
);


CREATE TABLE `projet`.`pointcook`
(
	`idPointCook` INT NOT NULL,
    `nbCook` INT NOT NULL,
    `idCdR` INT NOT NULL,
	PRIMARY KEY (`idPointCook`),
    FOREIGN KEY (`idCdR`) REFERENCES `projet`.`cdr`(`idCdR`)
);

CREATE TABLE `projet`.`cooking`
(
	`idCooking` INT NOT NULL,
	PRIMARY KEY (`idCooking`)
);