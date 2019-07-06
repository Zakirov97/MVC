CREATE DATABASE BestHookah
GO
use BestHookah
GO
CREATE TABLE UsersForNotifications(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	Mail VARCHAR(255) NOT NULL,
	Phone VARCHAR(255) NOT NULL
)

GO

INSERT INTO UsersForNotifications
VALUES 
	('Mail1@mail.ru','+7777123456'),
	('Mail2@mail.ru','+7777123456'),
	('Mail3@mail.ru','+7777123456'),
	('Mail4@mail.ru','+7777123456'),
	('Mail5@mail.ru','+7777123456');

GO
CREATE TABLE Reserve(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(255) NOT NULL,
	Mail VARCHAR(255) NOT NULL,
	Phone VARCHAR(255) NOT NULL,
	[Message] VARCHAR(255) NOT NULL
)
GO 
INSERT INTO Reserve
VALUES
	('Daifei','ReserveMail1@mail.ru','+7777111111','Message1'),
	('Longfei','ReserveMail2@mail.ru','+7777222222','Message2'),
	('Shalfei','ReserveMail3@mail.ru','+7777333333','Message3'),
	('Morfei','ReserveMail4@mail.ru','+7777444444','Message4'),
	('Porfei','ReserveMail5@mail.ru','+7777555555','Message5');
GO
CREATE TABLE HookahBarDrinks(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(255) NOT NULL,
	Price FLOAT NOT NULL,
	[Description] VARCHAR(255) NOT NULL,
	ImgPath VARCHAR(255) NOT NULL,
	TableName VARCHAR(255) NOT NULL
)
GO 
INSERT INTO HookahBarDrinks
VALUES
	('HOOKAH',32.99,'Al Fakher, Nakhla, Fumari, Vantage by Starbuzz, Tangiers, Starbuzz, Lavoo, Dark Side.','../Content/uploads/2018/11/mt-1616-home-img-1.jpg','HOOKAH BAR'),
	('FRUIT BOWL',36.99,'Try our fruit bowl hookah with Grapefruit, Orange, Apple, Pineapple, Melon.','../Content/uploads/2018/11/mt-1616-home-img-2.jpg','HOOKAH BAR'),
	('ART HOOKAH',49.99,'These all glass hookah are created using only the highest quality of glass.','../Content/uploads/2018/11/mt-1616-home-img-3.jpg','HOOKAH BAR'),
	('HIGH HOOKAH',79.99,'It has special filters that make the smoking experience completely different.','../Content/uploads/2018/11/mt-1616-home-img-4.jpg','HOOKAH BAR'),
	('MINT-TASTIC',32.99,'Try our gum-mint hookah with chocolate, ice cream, chocolate shake, cream.','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-1.jpg', 'HOOKAH BAR'),
	('VANILLA HOOKAH',36.99,'Try our premium vanilla hookah with peach, pomegranate, strawberry, cream.','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-2.jpg','HOOKAH BAR'),
	('BLUEBERRY CAKE',49.99,'Premium blueberry hookah with vanilla cake, gum-mint, chocolate, cream.','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-3.jpg','HOOKAH BAR'),
	('TASTY FRUIT COCKTAIL',79.99,'It has a special fruit flavor that makes the experience completely different.','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-4.jpg','DRINKS'),
	('COSMO',35.95,'','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-5.jpg','DRINKS'),
	('MOHITO',30.50,'','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-6.jpg','DRINKS'),
	('WINE',21.60,'','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-7.jpg','DRINKS'),
	('LIQUOR',28.30,'','../Content/uploads/2018/11/mt-1616-hookah-_bar-img-8.jpg','DRINKS');
GO
CREATE TABLE MenuSections(
ID INT NOT NULL IDENTITY PRIMARY KEY,
[Name] VARCHAR(255) NOT NULL
)
GO
INSERT INTO MenuSections(Name)
SELECT DISTINCT TableName FROM HookahBarDrinks
GO
SELECT * FROM UsersForNotifications
SELECT * FROM Reserve
SELECT * FROM HookahBarDrinks
SELECT * FROM MenuSections
