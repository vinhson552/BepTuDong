create database SCADABepTuDongV3
Go

use SCADABepTuDongV3
go


create table Ingredient
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Unit nvarchar(max)
)
go

create table Recipe
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Describe nvarchar(max),
	Box1 nvarchar(max),
	Box2 nvarchar(max),
	Box3 nvarchar(max),
	Box4 nvarchar(max),
	Unit1 nvarchar(100),
	Unit2 nvarchar(100),
	Unit3 nvarchar(100),
	Unit4 nvarchar(100),

)
go

create table StepRecipe
(
	Id int identity(1,1) primary key,
	IdRecipe int not null,
	NumberStep int,
	DisplayName nvarchar(max),
	_Param nvarchar(max),
	_Temp int default 0,
	_Hours int default 0,
	_Minutes int default 0,
	_Seconds int default 0

	foreign key(IdRecipe) references Recipe(Id)
)
go

create table UserRole
(
	Id int identity(1, 1) primary key,
	DisplayName nvarchar(max)
)
go

insert into UserRole(DisplayName) values(N'Admin')
go
insert into UserRole(DisplayName) values(N'Staff')
go

create table Users
(
	Id int identity(1, 1) primary key,
	IdRole int not null,
	UserName nvarchar(100),
	Password nvarchar(max),
	DisplayName nvarchar(max),
	Phone nvarchar(100),
	Email nvarchar(100),
	MoreInfo nvarchar(max)
	
	foreign key(IdRole) references UserRole(Id)
)
go

insert into Users(DisplayName, UserName, Password, IdRole) values(N'Minh Dn', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
go
insert into Users(DisplayName, UserName, Password, IdRole) values(N'Ten nhan vien', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
go

create table RobotActionCode
(
	ID int identity(1,1) primary key,
	ActionName nvarchar(max),
	GCode nvarchar(max)
)
go

create table IngredientUnit
(
	ID int identity(1,1) primary key,
	UnitName nvarchar(max)
)
go

create table CookerAddress
(
	ID int identity(1,1) primary key,
	CookerName nvarchar(max),
	CookerAddress nvarchar(100)
)
go 

insert into RobotActionCode (ActionName, Gcode)
values (N'Thêm hộp 1',
'G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0
G20 X=-137.519 Y=-405.5484 Z=149.2059 A=-157.5389 B=171.843 C=91.737 D=0
G06 T=1000
G06 O=P0.1
G06 T=1000
G20 X=-138.9463 Y=-413.0557 Z=402.2005 A=-174.9423 B=167.9703 C=91.9879 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-116.7336 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=-138.9463 Y=-413.0557 Z=402.2005 A=-174.9423 B=167.9703 C=91.9879 D=0
G20 X=-137.519 Y=-405.5484 Z=149.2059 A=-157.5389 B=171.843 C=91.737 D=0
G06 O=P0.0
G06 T=1000
G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0'
)
go

insert into RobotActionCode (ActionName, Gcode)
values (N'Thêm hộp 2',
'G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0
G20 X=-47.3853 Y=-417.8915 Z=143.525 A=-96.469 B=173.9749 C=96.5048 D=0
G06 T=1000
G06 O=P0.1
G06 T=1000
G20 X=-46.4748 Y=-409.8614 Z=342.3621 A=-96.4693 B=172.7197 C=96.5213 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-116.7336 D=0
G06 T=1000
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=-46.4748 Y=-409.8614 Z=342.3621 A=-96.4693 B=172.7197 C=96.5213 D=0
G20 X=-47.3853 Y=-417.8915 Z=143.525 A=-96.469 B=173.9749 C=96.5048 D=0
G06 O=P0.0
G06 T=1000
G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0'
)
go

insert into RobotActionCode (ActionName,GCode)
values (N'Thêm hộp 3',
'G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0
G20 X=6.613 Y=-421.5826 Z=145.7114 A=-63.4358 B=173.3154 C=95.1154 D=0
G06 T=1000
G06 O=P0.1
G06 T=1000
G20 X=4.6148 Y=-424.7217 Z=351.8435 A=-43.8847 B=172.5803 C=93.5116 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-116.7336 D=0
G06 T=1000
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=4.6148 Y=-424.7217 Z=351.8435 A=-43.8847 B=172.5803 C=93.5116 D=0
G20 X=6.613 Y=-421.5826 Z=145.7114 A=-63.4358 B=173.3154 C=95.1154 D=0
G06 O=P0.0
G06 T=1000
G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0'
)
go

insert into RobotActionCode (ActionName,GCode)
values (N'Thêm hộp 4',
'G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0
G20 X=103.7549 Y=-427.9266 Z=143.4114 A=-26.2586 B=166.8328 C=106.2315 D=0
G06 T=1000
G06 O=P0.1
G06 T=1000
G20 X=97.4742 Y=-426.9708 Z=305.1348 A=-3.8281 B=162.5942 C=106.2452 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-116.7336 D=0
G06 T=1000
G20 X=467.7158 Y=20.363 Z=478.8792 A=2.8722 B=178.8393 C=-2.4933 D=0
G20 X=353.4838 Y=0 Z=564.5886 A=0 B=175.5899 C=0.0862 D=0
G20 X=97.4742 Y=-426.9708 Z=305.1348 A=-3.8281 B=162.5942 C=106.2452 D=0
G20 X=103.7549 Y=-427.9266 Z=143.4114 A=-26.2586 B=166.8328 C=106.2315 D=0
G06 O=P0.0
G06 T=1000
G20 X=-14.7055 Y=-353.2141 Z=192.3335 A=-92.3835 B=179.1239 C=92.3843 D=0'
)
go

insert into IngredientUnit (UnitName) values ('KG')
go

insert into IngredientUnit (UnitName) values ('G')
go

insert into IngredientUnit (UnitName) values ('L')
go

insert into IngredientUnit (UnitName) values ('ML')
go

--create table History
--(
--	--Id int identity(1, 1) primary key,
--	Id nvarchar(128) primary key,
--	IdRecipe int not null,
--	IdUsers int not null,
--	Datas datetime
	
--	--foreign key(IdRecipe) references Recipe(Id),
--	--foreign key(IdUsers) references Users(Id)
	
--)
--go


--INSERT into Ingredient(DisplayName) VALUES(N'Thịt bò')
--GO

