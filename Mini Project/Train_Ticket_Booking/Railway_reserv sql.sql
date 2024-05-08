Create Database Railway_reservation;
use Railway_reservation

CREATE TABLE Trains (
    Train_no INT,
    Train_name VARCHAR(50),
    Source_loc VARCHAR(50),
    Destination VARCHAR(50),
    Date_of_Travel DATE,
    Train_Status Bit not null Default 1,
    PRIMARY KEY (Train_no)
);

Insert into Trains (Train_no,Train_Name,Source_loc,Destination,Date_of_Travel,Train_Status)
values
(12658, 'Mumbai-Delhi Express', 'Mumbai', 'Delhi', '2024-05-11', 1),
(12659, 'Shatabdi Express',  'Mumbai', 'Delhi', '2024-04-11', 1),
(12677, 'Lucknow Express',  'Kolkata', 'Lucknow', '2024-05-20', 1),
(12678, 'Hyderabad Express', 'Vijayawada', 'Hyderabad', '2024-05-21', 1),
(12679, 'ChennaiExpress',  'Bangalore', 'Chennai', '2024-05-20', 1);

Select * from Trains;

Create Table Booked_Tickets(Ticket_Id numeric(6) Primary key,
Train_no int foreign key references Trains(Train_no),
Class varchar(7),
Passenger_Name varchar(50),
Gender varchar(15))

Select*From Booked_Tickets

CREATE TABLE Cancellation_Data (
    Canc_ID INT  PRIMARY KEY,
	Train_no int foreign key references Trains(Train_no),
    Ticket_ID INT,
    Canc_Date DATE,
	Status Varchar(50),
    Refund_Amount INT);


	Create Table Available_Seats(Sequence numeric(3) Identity ,
	Train_No INT  foreign key references Trains(Train_No),First_AC numeric(5),Second_AC numeric(5),Sleeper numeric(5));

	Insert into Available_Seats Values
	(12658,40,50,60),
	(12659,40,50,60),
	(12677,40,50,60),
	(12678,40,50,60),
	(12679,40,50,60);
	select * from Available_Seats

	delete from Trains where Train_no=20654;

	Select * from Cancellation_Data;
	Select * from Available_Seats;
	delete  from Cancellation_Data;


	---Delete from Booked_Tickets;


	Create table Admin_Login(Admin_Code Int Primary key, Admin_userName varchar(20), 
	Admin_pass varchar(30));

create table user_login(
user_Code int not null primary key,
password varchar(20),
)

Create Table Fare_S(SequenceNo int identity,
Train_id INT foreign key references Trains(Train_No),
First_ACf numeric(5),Second_ACf numeric(5),Sleeperf numeric(5));

Insert into  Fare_S Values(12658,4000,1800,1200),
(12659,3000,2000,1200),
(12677,4500,3000,2000),
(12678,3500,2500,1500),
(12679,3050,2050,1050);

Select * from Fare_S;
select*from Admin_Login;


--Remove Seat Procedure
Create or alter proc RemoveSeat(@trainNo int, @class1 varchar(15))
as
begin
if @class1='1Ac'
update Available_Seats set First_AC =First_AC-1 where Train_No=@trainNo
else if @class1 ='2Ac'
update Available_Seats set Second_AC =Second_AC-1 where Train_No=@trainNo
else if @class1 ='SL'
update Available_Seats set Sleeper =Sleeper-1 where Train_No=@trainNo
end



----Add seat procedure
Create or alter proc AddSeat(@trainNo int, @class1 varchar(15))
as
begin
if @class1='1Ac'
update Available_Seats set First_AC =First_AC+1 where Train_No=@trainNo
else if @class1 ='2Ac'
update Available_Seats set Second_AC =Second_AC+1 where Train_No=@trainNo
else if @class1 ='SL'
update Available_Seats set Sleeper =Sleeper+1 where Train_No=@trainNo
end




Create or alter proc Add_Seatdet(@trainid numeric(5),@fac int, @sac int, @tac int)

as

begin

insert into   Available_Seats 

values(@trainid,@fac,@sac,@tac)

end


Create or alter proc Add_Fairdet(@train_id numeric(5),@facf int, @sacf int, @tacf int)
as
begin
insert into  Fare_S values(@train_id,@facf,@sacf,@tacf)
end

