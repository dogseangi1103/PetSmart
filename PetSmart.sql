-- === Delete Table ===

drop table if exists Product

go

-- === Create Table ===

create table Product
(
	Id int primary key identity not null
	, [Name] nvarchar(100) not null
)

go

-- === Create Data ===

insert Product
([Name])
values
(N'【法國皇家】中型成犬MA 15KG')
, (N'【法國皇家】大型成犬MXA 15KG')
, (N'Hill’s 希爾思™寵物食品 成犬 小顆粒 雞肉與大麥 12公斤')

go

-- === Show Data ===

select * from Product
