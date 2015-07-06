function processVehicleParkCommands(commands) {
	'use strict';
	// -------------------------- Helper functions --------------------------
	Object.prototype.extend = function(parent) {
		this.prototype = Object.create(parent.prototype);
		this.prototype.constructor = this;
	};
	// **********************************************************************
	
	var Models = (function() {
		var Employee = (function() {
			function Employee(name, position, grade) {
				this.setName(name);
				this.setPosition(position);
				this.setGrade(grade);
			}
			
			Employee.prototype.getName = function() {
				return this._name;
			};
			
			Employee.prototype.setName = function(name) {
				if (name === undefined || name === "") {
					throw new Error("Name cannot be empty or undefined.");
				}
				this._name = name;
			};
			
			Employee.prototype.getPosition = function() {
				return this._position;
			};
			
			Employee.prototype.setPosition = function(position) {
				if (position === undefined || position === "") {
					throw new Error("Position cannot be empty or undefined.");
				}
				this._position = position;
			};
			
			Employee.prototype.getGrade = function() {
				return this._grade;
			};
			
			Employee.prototype.setGrade = function(grade) {
				if (grade === undefined || isNaN(grade) || grade < 0) {
					throw new Error("Grade cannot be negative.");
				}
				this._grade = grade;
			};
			
			Employee.prototype.toString = function() {
				return " ---> " + this.getName() +
					",position=" + this.getPosition();
			};
			
			return Employee;
		}());
		
		var Vehicle = (function() {
			function Vehicle(brand, age, terrainCoverage, numberOfWheels) {
				if (this.constructor === Vehicle) {
					throw new Error("Can't instantiate abstract class!");
				}
				
				this.setBrand(brand);
				this.setAge(age);
				this.setTerrainCoverage(terrainCoverage);
				this.setNumberOfWheels(numberOfWheels);
			}
			
			Vehicle.prototype.getBrand = function() {
				return this._brand;
			};
			
			Vehicle.prototype.setBrand = function(value) {
				this._brand = value;
			};
			
			Vehicle.prototype.getAge = function() {
				return this._age;
			};
			
			Vehicle.prototype.setAge = function(value) {
				this._age = value;
			};
			
			Vehicle.prototype.getTerrainCoverage = function() {
				return this._terrainCoverage;
			};
			
			Vehicle.prototype.setTerrainCoverage = function(value) {
				this._terrainCoverage = value;
			};
			
			Vehicle.prototype.getNumberOfWheels = function() {
				return this._numberOfWheels;
			};
			
			Vehicle.prototype.setNumberOfWheels = function(value) {
				this._numberOfWheels = value;
			};
			
			Vehicle.prototype.toString = function() {
				return '-> ' + this.constructor.name +
					': brand=' + this.getBrand() +
					',age=' + this.getAge() +
					',terrainCoverage=' + this.getTerrainCoverage() +
					',numberOfWheels=' + this.getNumberOfWheels();
			};
		}());
		
		var Bike = (function() {
			function Bike(brand, age, terrainCoverage, frameSize, numberOfShifts) {
				Vehicle.call(this, brand, age, terrainCoverage, 2);
				this.setFrameSize(frameSize);
				this.setNumberOfShifts(numberOfShifts);
			}
			
			Bike.extend(Vehicle);
			
			Bike.prototype.getFrameSize = function() {
				return this._frameSize;
			};
			
			Bike.prototype.setFrameSize = function(value) {
				this._frameSize = value;
			};
			
			Bike.prototype.getNumberOfShifts = function() {
				return this._numberOfShifts;
			};
			
			Bike.prototype.setNumberOfShifts = function(value) {
				this._numberOfShifts = value;
			};
			
			Bike.prototype.toString = function() {
				return Vehicle.prototype.toString.call(this) +
					',frameSize=' + this.getFrameSize() +
					',numberOfShifts=' + this.getNumberOfShifts();
			};
			
			return Bike;
		}());
		
		var Automobile = (function() {
			function Automobile(brand, age, terrain, wheels, consumption, typeOfFuel) {
				if (this.constructor === Automobile) {
					throw new Error("Can't instantiate abstract class!");
				}

				Vehicle.call(this, brand, age, terrain, wheels);
				this.setConsumption(consumption);
				this.setTypeOfFuel(typeOfFuel);
			}
			
			Automobile.extend(Vehicle);
			
			Automobile.prototype.getConsumption = function() {
				return this._consumption;
			};
			
			Automobile.prototype.setConsumption = function(value) {
				this._consumption = value;
			};
			
			Automobile.prototype.getTypeOfFuel = function() {
				return this._typeOfFuel;
			};
			
			Automobile.prototype.setTypeOfFuel = function(value) {
				this._typeOfFuel = value;
			};
			
			Automobile.prototype.toString = function() {
				return Vehicle.prototype.toString.call(this) +
					',consumption=[' + this.getConsumption() +
					'l/100km ' + this.getTypeOfFuel();
			};
			
			return Automobile;
		}());
		
		var Truck = (function() {
			function Truck(brand, age, consumption, typeOfFuel, numberOfDoors) {
				Automobile.call(this, brand, age, 'all', 4, consumption, typeOfFuel);
				this.setNumberOfDoors(numberOfDoors);
			}

			Truck.extend(Automobile);

			Truck.prototype.getNumberOfDoors = function() {
				return this._numberOfDoors;
			};

			Truck.prototype.setNumberOfDoors = function(value) {
				this._numberOfDoors = value;
			};

			Truck.prototype.toString = function() {
				return Automobile.prototype.toString.call(this) +
					',numberOfDoors=' + this.getNumberOfDoors();
			};

			return Truck;
		}());
		
		var Limo = (function() {
			function Limo(brand, age, wheels, consumption, typeOfFuel) {
				if (wheels == undefined) {
					wheels = "4";
				}

				Automobile.call(this, brand, age, 'road', wheels, consumption, typeOfFuel);
				this._employees = [];
			}

			Limo.extend(Automobile);

			Limo.prototype.getEmployees = function() {
				return this._employees;
			};

			Limo.prototype.appendEmployee = function(employee) {
				var index = this._employees.indexOf(employee);
				if (index < 0) {
					this._employees.push(employee);
				}
			};

			Limo.prototype.detachEmployee = function(employee) {
				var index = this._employees.indexOf(employee);
				if (index < 0) {
					throw new Error();
				}

				this._employees.splice(index, 1);
			};

			Limo.prototype.toString = function() {
				var automobile = Automobile.prototype.toString.call(this);
				automobile += "\n" + " --> Employees, allowed to drive:";
				if (this._employees.length == 0) {
					automobile += " ---";
				}

				for (var i = 0; i < this._employees.length; i++) {
					automobile += "\n" + this._employees[i].toString();
				}

				return automobile;
			};

			return Limo;
		}());
		
		return {
			Employee: Employee,
			Bike: Bike,
			Truck: Truck,
			Limo: Limo
		}
	}());
	
	var ParkManager = (function() {
		var _vehicles;
		var _employees;

		function init() {
			_vehicles = [];
			_employees = [];
		}

		var CommandProcessor = (function() {

			function processInsertCommand(command) {
				var object;

				switch (command["type"]) {
					case "bike":
						object = new Models.Bike(
							command["brand"],
							parseFloat(command["age"]),
							command["terrain-coverage"],
							parseFloat(command["frame-size"]),
							command["number-of-shifts"]);
						_vehicles.push(object);
						break;
					case "truck":
						object = new Models.Truck(
							command["brand"],
							parseFloat(command["age"]),
							command["terrain-coverage"],
							parseFloat(command["consumption"]),
							command["type-of-fuel"],
							parseFloat(command["number-of-doors"]));
						_vehicles.push(object);
						break;
					case "limo":
						object = new Models.Limo(
							command["brand"],
							parseFloat(command["age"]),
							parseFloat(command["number-of-wheels"]),
							parseFloat(command["consumption"]),
							command["type-of-fuel"]);
						_vehicles.push(object);
						break;
					case "employee":
						object =
							new Models.Employee(command["name"], command["position"], parseFloat(command["grade"]));
						_employees.push(object);
						break;
					default:
						throw new Error("Invalid type.");
				}

				return object.constructor.name + " created.";
			}

			function processDeleteCommand(command) {
				var object,
					index;

				switch (command["type"]) {
					case "employee":
						object = getEmployeeByName(command["name"]);
						_vehicles.forEach(function(t) {
							if (t instanceof Models.Limo && t.getEmployees().indexOf(object) !== -1) {
								t.detachEmployee(object);
							}
						});
						index = _employees.indexOf(object);
						_employees.splice(index, 1);
						break;
					case "bike":
						object = getVehicleByBrandAndType(command["brand"], command["type"]);
						index = _vehicles.indexOf(object);
						_vehicles.splice(index, 1);
						break;
					case "truck":
						object = getVehicleByBrandAndType(command["brand"], command["type"]);
						index = _vehicles.indexOf(object);
						_vehicles.splice(index, 1);
						break;
					case "limo":
						object = getVehicleByBrandAndType(command["brand"], command["type"]);
						index = _vehicles.indexOf(object);
						_vehicles.splice(index, 1);
						break;
					default:
						throw new Error("Unknown type.");
				}

				return object.constructor.name + " deleted.";
			}

			function processListCommand(command) {
				return formatOutputList(_vehicles);
			}

			function processAppendEmployeeCommand(command) {
				var employee = getEmployeeByName(command["name"]);
				var limos = getLimosByBrand(command["brand"]);

				for (var i = 0; i < limos.length; i++) {
					limos[i].appendEmployee(employee);
				}
				return "Added employee to possible Limos.";
			}

			function processDetachEmployeeCommand(command) {
				var employee = getEmployeeByName(command["name"]);
				var limos = getLimosByBrand(command["brand"]);

				for (var i = 0; i < limos.length; i++) {
					limos[i].detachEmployee(employee);
				}

				return "Removed employee from possible Limos.";
			}

			// Functions below are not revealed

			function getVehicleByBrandAndType(brand, type) {
				for (var i = 0; i < _vehicles.length; i++) {
					if (_vehicles[i].constructor.name.toString().toLowerCase() === type &&
						_vehicles[i].getBrand() === brand) {
						return _vehicles[i];
					}
				}
				throw new Error("No " + brand + " with such brand exists.");
			}

			function getLimosByBrand(brand) {
				var currentVehicles = [];
				for (var i = 0; i < _vehicles.length; i++) {
					if (_vehicles[i] instanceof Models.Limo &&
						_vehicles[i].getBrand() === brand) {
						currentVehicles.push(_vehicles[i]);
					}
				}
				if (currentVehicles.length > 0) {
					return currentVehicles;
				}
				throw new Error("No Limo with such brand exists.");
			}

			function getEmployeeByName(name) {

				for (var i = 0; i < _employees.length; i++) {
					if (_employees[i].getName() === name) {
						return _employees[i];
					}
				}
				throw new Error("No Employee with such name exists.");
			}

			function formatOutputList(output) {
				var queryString = "List Output:\n";

				if (output.length > 0) {
					queryString += output.join("\n");
				} else {
					queryString = "No results.";
				}

				return queryString;
			}

			function processListEmployees(commandArgs) {
				var grade = commandArgs["grade"];
				_employees.sort(function(a, b) {
					return a.getName() > b.getName();
				});
				var result = "List Output:" + "\n";
				for (var i = 0; i < _employees.length; i++) {
					if (_employees[i].getGrade() >= grade || grade === "all") {
						result += _employees[i].toString() + "\n";
					}
				}
				return result;
			}

			return {
				processInsertCommand: processInsertCommand,
				processDeleteCommand: processDeleteCommand,
				processListCommand: processListCommand,
				processAppendEmployeeCommand: processAppendEmployeeCommand,
				processDetachEmployeeCommand: processDetachEmployeeCommand,
				processListEmployees: processListEmployees
			}
		}());

		var Command = (function() {
			function Command(cmdLine) {
				this._cmdArgs = processCommand(cmdLine);
			}

			function processCommand(cmdLine) {
				var parameters = [],
					matches = [],
					pattern = /(.+?)=(.+?)[;)]/g,
					key,
					value,
					split;

				split = cmdLine.split("(");
				parameters["command"] = split[0];
				while ((matches = pattern.exec(split[1])) !== null) {
					key = matches[1];
					value = matches[2];
					parameters[key] = value;
				}

				return parameters;
			}

			return Command;
		}());

		function executeCommands(cmds) {
			var commandArgs = new Command(cmds)._cmdArgs,
				action = commandArgs["command"],
				output;

			switch (action) {
				case "insert":
					output = CommandProcessor.processInsertCommand(commandArgs);
					break;
				case "delete":
					output = CommandProcessor.processDeleteCommand(commandArgs);
					break;
				case "append-employee":
					output = CommandProcessor.processAppendEmployeeCommand(commandArgs);
					break;
				case "detach-employee":
					output = CommandProcessor.processDetachEmployeeCommand(commandArgs);
					break;
				case "list":
					output = CommandProcessor.processListCommand(commandArgs);
					break;
				case "list-employees":
					output = CommandProcessor.processListEmployees(commandArgs);
					break;
				default:
					throw new Error("Unsupported command.");
			}

			return output;
		}

		return {
			init: init,
			executeCommands: executeCommands
		}
	}());

	var output = "";
	ParkManager.init();

	commands.forEach(function(cmd) {
		var result;
		if (cmd != "") {
			try {
				result = ParkManager.executeCommands(cmd) + "\n";
			}
			catch (e) {
				result = "Invalid command." + "\n";
				//result = e.message + "\n";
			}
			output += result;
		}
	});

	return output;
}