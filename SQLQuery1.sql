if object_id('conn','U') is not null drop table conn;
if object_id('drill','U') is not null drop table drill;
if object_id('brick','U') is not null drop table brick;

create table drill (
drill_id int identity primary key not null,
drill_speed int,
drill_storage int ,
drill_fuel int,
drill_score int
);
go

create table brick (
brick_id int identity primary key not null,
brick_type varchar(200),
brick_x int,
brick_y int
);
go

create table conn(
conn_id int identity primary key not null,
conn_drill_id int foreign key references drill(drill_id) on delete cascade, 
conn_brick_id int foreign key references brick(brick_id) on delete cascade
);
go

--INSERT INTO drill values(100,4,24,33);
--INSERT INTO drill values(789,7,45,46);
--INSERT INTO drill values(345,9,55,64);
--INSERT INTO drill values(567,10,99,14);
--INSERT INTO drill values(345,34,54,25);

--INSERT INTO brick values('gold',45,76);
--INSERT INTO brick values('brick',57,30);
--INSERT INTO brick values('gold',27,10);
--INSERT INTO brick values('brick',17,46);
--INSERT INTO brick values('gold',97,20);

--INSERT INTO conn values(1,1);
--INSERT INTO conn values(1,2);
--INSERT INTO conn values(1,3);
--INSERT INTO conn values(1,4);
--INSERT INTO conn values(1,5);



