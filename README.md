# Medicine Cabinet

####  _June 22nd, 2017_

#### By _**Kimlan Nguyen, David Rolfs, Leah Sherrell & Dylan Dills**_

## Description
Medicine Cabinet is a webpage where the user can look up remedies and ailments and find information about them. They can see what remedies are used to treat specific ailments and learn about the side effects.

## Repository
https://github.com/kimlan1510/Medicine

## Specs

| Description | input | output |
| ------------- |:-------------:| -----:|
| User clicks on remedies link  | click | all remedies display on webpage |
| User clicks on ailments link | click | all ailments display on webpage|
| User clicks on single remedy link | click | detailed information about that remedy is taken from the database and displayed on webpage.|
| User clicks on single ailment link | click | detailed information about that ailment is taken from the database and displayed on webpage.|
| admin page allows user to enter new remedies, ailments, and categories into database | submit | new information is added to sql database |
| admin is required to enter correct password to edit information | password is: password | admin page displays |
| admin can edit and delete remedies, ailments, and categories in database using admin page | types new information | database is updated and new information is shown|



## MVP

#### _Backend_
* Admin is able to add new remedies to database.
* Admin is able to add new ailments to database.
* Admin is able to edit and delete remedies and ailments in database.
* Users can see all remedies and ailments on the webpage.
* Users can click on an image of a remedy or an ailment and that will take them to a webpage that show detail information about that remedy or ailment.
#### _FrontEnd_


## Setup/Installation Requirements

* First download all the files by going to  https://github.com/kimlan1510/Medicine
* Click the "download or clone" button and copy the link.
* In your computers terminal type "git clone" & paste the copied link.
* Once downloaded enter dnu restore into the terminal.
* Now open SMSS
* Select File > Open > File and select medicine.sql
* Paste "CREATE DATABASE medicine; GO" at top of file (without the quotes)
* Save the file and click "Execute"
* After all files have been downloaded and restored enter dnx kestrel into the terminal to run the server.
* Open web browser of your choice and go to http://localhost:5004/ to view root page.



## Known bugs



## Support and contact details
  * kimlan1510@gmail.com
  * rolfs97@yahoo.com
  * dylan.dills@gmail.com
  * leahsherrell@icloud.com


## Technologies Used

_HTML, CSS, JavaScript, jQuery, Bootstrap, SASS, C#, Razor, Xunit, .NET, Nancy_

### License
 This program is licensed under MIT license.

Copyright (c) 2017 **_Kimlan Nguyen, David Rolfs, Leah Sherrell & Dylan Dills_**
