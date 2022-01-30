-- === Delete Table ===

drop table if exists Product

go

-- === Create Table ===

create table Product
(
	Id int primary key identity not null
	, [Name] nvarchar(100) not null
	, IsDeleted bit not null default 0
)

go

-- === Create Data ===

insert Product
([Name], IsDeleted)
values
(N'【法國皇家】中型成犬MA 15KG', 0)
, (N'【法國皇家】大型成犬MXA 15KG', 1)
, (N'Hill’s 希爾思™寵物食品 成犬 小顆粒 雞肉與大麥 12公斤', 0)

go

-- === Show Data ===

select * from Product
