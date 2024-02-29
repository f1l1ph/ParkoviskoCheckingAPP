# ParkoviskoCheckingAPP

This is my repository for a school project. The project contains:

- Database
- Web Api 1([ParkingAppWebApi](https://github.com/f1l1ph/ParkingAppWebApi/) repository)
- Mobile app(this repository)
- Web Api 2(![PythonBackend-parkingApp](https://github.com/f1l1ph/ParkoviskoCheckingAPP) repository)

Project was made to check on whether cars on school parking lots belong to students and teachers or to someone else who isn't related to school. 
License plate numbers and details are all stored in database and Web Api 1 is communicating with database. 
User can add, remove, edit or look at cars that are stored in database. 
User can also verify if car's license plate number is stored in database based on picture of license plate (in this case webApi 1 communicates with webApi 2 where image processing happens).

---

Front end details:
 - Project type: .Net MAUI Blazor hybrid
 - .Net version: 8
 - IDE: Visual studio community 2022 preview
 - Libraries/Tools:
   - Refit - for communication
   - Validation - Regex and Fluent validation

Before doing anything, user has to login.<br>

---

<em>Page for adding cars</em><br>
![addCarScreenshot](https://github.com/f1l1ph/ParkoviskoCheckingAPP/assets/50553234/9c4c0c6d-333d-43c1-9b19-f9ab5de2d8b3)

<em>Page containing cars</em><br>
![cars_Screenshot](https://github.com/f1l1ph/ParkoviskoCheckingAPP/assets/50553234/15a7f04d-df6b-4780-948b-18df8d1fb4df)

<em>Page for checking cars, can also be checked based on image of license plate.</em>
![CheckCarScreensho](https://github.com/f1l1ph/ParkoviskoCheckingAPP/assets/50553234/d3d769f0-1807-4ea8-9ff2-77c2ca088b64)
