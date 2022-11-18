create table Owners(
	Id uuid not null primary key,
	FirstName varchar(25) not null,
	LastName varchar(25) not null,
	DriverLicense varchar(20) not null
);

create table Vehicles (
    Id uuid not null primary key,
    Brand varchar(25) not null,
    Vin varchar(25) not null,
    Color varchar(25) not null,
    Year int not null,
    Owner_Id uuid not null references Owners(Id)
);

create table Claims (
    Id uuid not null primary key,
    Description varchar(50) not null,
    Status varchar(25) not null,
    Date Date not null,
    Vehicle_Id uuid not null references Vehicles(Id)
)

