create table Owners(
	Id uuid primary key,
	FirstName varchar(25),
	LastName varchar(25),
	DriverLicense varchar(20)
);

create table Vehicles (
    Id uuid primary key,
    Brand varchar(25),
    Vin varchar(25),
    Color varchar(25)
    Year Date,
    constraint fk_Owner_Id foreign key (Owner_Id) references Owners (Id)
);

create table Claims (
    Id uuid primary key,
    Description varchar(50),
    Status varchar(25),
    'Date' Date,
    constraint fk_Vehicle_Id foreign key (Vehicle_Id) references Vehicles (Id) 
);