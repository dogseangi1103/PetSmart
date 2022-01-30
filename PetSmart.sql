-- === Delete Table ===

drop table if exists OrderItem
drop table if exists [Order]
drop table if exists Product

go

-- === Create Table ===

create table Product
(
	Id int primary key identity not null
	, [Name] nvarchar(100) not null
	, IsDeleted bit not null default 0
)

create table [Order]
(
	Id int primary key identity not null
	, [Address] nvarchar(100) not null
	-- 1=未付款 2=已付款 3=已送達
	, [Status] int not null
)

create table OrderItem
(
	Id int primary key identity not null
	, OrderId int not null
	, ProductName nvarchar(100) not null
	, Price decimal not null
	, foreign key (OrderId) references [Order](Id)
)

go

-- === Create Data ===

insert Product
([Name], IsDeleted)
values
(N'【法國皇家】中型成犬MA 15KG', 0)
, (N'【法國皇家】大型成犬MXA 15KG', 1)
, (N'Hill’s 希爾思™寵物食品 成犬 小顆粒 雞肉與大麥 12公斤', 0)
, (N'Hill’s 希爾思™寵物食品 幼犬 小顆粒 雞肉與大麥 12公斤', 0)

insert [Order]
([Address], [Status])
values
(N'台北市中正區林森北路9巷13號', 1)
, (N'新北市板橋區文化路一段270巷3弄6號', 2)
, (N'新北市土城區立德路2號', 3)

insert OrderItem
(OrderId, ProductName, Price)
values
(1, N'【法國皇家】中型成犬MA 15KG', 10)
, (1, N'Hill’s 希爾思™寵物食品 成犬 小顆粒 雞肉與大麥 12公斤', 20)
, (2, N'【法國皇家】中型成犬MA 15KG', 30)
, (3, N'【法國皇家】中型成犬MA 15KG', 30)

go

-- === Show Data ===

select * from Product
select * from [Order]
select * from OrderItem
