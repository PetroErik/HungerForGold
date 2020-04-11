if object_id('conn','U') is not null drop table conn;
if object_id('drill','U') is not null drop table drill;
if object_id('brick','U') is not null drop table brick;

create table drill (
drill_id int identity primary key not null,
drill_speed int,
drill_storage int,
drill_fuel int,
drill_score int,
drill_x int,
drill_y int
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




