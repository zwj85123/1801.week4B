create database Unit20200903
use Unit20200903

create table KuCun(
	Kid			int identity primary key,
	Kname		varchar(20),
	GuiGe		varchar(20),
	Kcount		int,
	Pici        int
)
select * from KuCun
create table GongYinShang(
	Gid int identity primary key,
	Gname varchar(20)
)
create table MingXi(
	Mid				int identity primary key,
	Mname			varchar(20),
	Mgg				varchar(20),
	Mtime			varchar(50),
	Gid				int,
	Sctime			varchar(50),
	Yxtime			varchar(50),
	Mcount			int,
	Mprice			varchar(20)
)
select * from MingXi m join GongYinShang g on m.Gid=g.Gid
select * from KuCun where Kid = 1