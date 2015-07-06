function processVehicleParkCommands(commands) {
	'use strict';

	Object.prototype.extend = function(parent) {
		this.prototype = Object.create(parent.prototype);
		this.prototype.constructor = this;
	};

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
			function Vehicle(brand, age, terrain, wheels) {
				if (this.constructor === Vehicle) {
					throw new Error("Can't instantiate abstract class Vehicle");
				} else {
					this.setBrand(brand);
					this.setAge(age);
					this.setTerrain(terrain);
					this.setWheels(wheels);
				}
			}

			Vehicle.prototype.setBrand = function(brand) {
				if (brand === undefined || typeof (brand) != 'string' || brand === "") {
					throw new Error("Brand cannot be empty or undefined.");
				}
				this._brand = brand;
			};

			Vehicle.prototype.setAge = function(age) {
				if (age === undefined || isNaN(age) || age < 0) {
					throw new Error("Age be negative.");
				}
				this._age = age.toFixed(1);
			};
			Vehicle.prototype.setTerrain = function(terrain) {
				if (terrain != "all" && terrain != "road") {
					throw new Error("Invalid terrain type");
				}
				this._terrain = terrain;
			};
			Vehicle.prototype.setWheels = function(wheels) {
				if (wheels === undefined || isNaN(wheels) || wheels < 0) {
					throw new Error("Number of wheells cannot  be negative.");
				}
				this._wheels = Math.round(wheels);
			};
			Vehicle.prototype.getBrand = function() {
				return this._brand;
			};
			Vehicle.prototype.getAge = function() {
				return this._age;
			};
			Vehicle.prototype.getTerrain = function() {
				return this._terrain;
			};
			Vehicle.prototype.getWheels = function() {
				return this._wheels;
			};
			Vehicle.prototype.toString = function() {
				var vehicle = " -> " + this.constructor.name + ": ";
				vehicle += "brand=" + this.getBrand() + ",age=" + this.getAge() + ",terrainCoverage="
				+ this.getTerrain() + ",numberOfWheels=" + this.getWheels();
				return vehicle;
			};
			return Vehicle;
		})();

		var Bike = (function() {
			function Bike(brand, age, terrain, frame, shifts) {
				Vehicle.call(this, brand, age, terrain, "2");
				this.setFrame(frame);
				this.setShifts(shifts);
			}

			Bike.extend(Vehicle);
			Bike.prototype.setFrame = function(frame) {
				if (frame === undefined || isNaN(frame) || frame < 0) {
					throw new Error("Frame size of wheells cannot  be negative.");
				}
				this._frame = frame;
			};
			Bike.prototype.setShifts = function(shifts) {
				if (shifts != undefined && shifts === "") {
					throw new Error("Name cannot be empty or undefined.");
				}
				this._shifts = shifts;
			};
			Bike.prototype.getFrame = function() {
				return this._frame;
			};
			Bike.prototype.getShifts = function() {
				return this._shifts;
			};
			Bike.prototype.toString = function() {
				var bike = Vehicle.prototype.toString.call(this);

				bike += ",frameSize=" + this.getFrame();
				if (this.getShifts() != undefined) {
					bike += ",numberOfShifts=" + this.getShifts();
				}
				return bike;
			};
			return Bike;
		})();

		var Automobile = (function() {
			function Automobile(brand, age, terrain, wheels, consumption, fuel) {
				if (this.constructor === Automobile) {
					throw new Error("Can't instantiate abstract class Vehicle");
				} else {
					Vehicle.call(this, brand, age, terrain, wheels);
					this.setConsumption(consumption);
					this.setFuel(fuel);
				}
			}

			Automobile.extend(Vehicle);
			Automobile.prototype.setConsumption = function(consumption) {
				if (consumption === undefined || isNaN(consumption) || consumption < 0) {
					throw new Error("Consumtion age be negative.");
				}
				this._consumption = Math.round(consumption);
			};
			Automobile.prototype.setFuel = function(fuel) {
				if (fuel === undefined || typeof (fuel) != 'string' || fuel === "") {
					throw new Error("Name cannot be empty or undefined.");
				}
				this._fuel = fuel;
			};
			Automobile.prototype.getConsumption = function() {
				return this._consumption;
			};

			Automobile.prototype.getFuel = function() {
				return this._fuel;
			};
			Automobile.prototype.toString = function() {
				var automobile = Vehicle.prototype.toString.call(this);

				automobile += ",consumption=[" + this.getConsumption() + "l/100km " + this.getFuel() + "]";
				return automobile;
			};
			return Automobile;
		})();

		var Truck = (function() {
			function Truck(brand, age, terrain, consumption, fuel, doors) {
				if (terrain === undefined) {
					terrain = "all";
				}
				Automobile.call(this, brand, age, terrain, "4", consumption, fuel);
				this.setDoors(doors);
			}

			Truck.extend(Automobile);
			Truck.prototype.setDoors = function(doors) {
				if (doors === undefined || isNaN(doors) || doors < 0) {
					throw new Error("Consumtion age be negative.");
				}
				this._doors = doors;
			};
			Truck.prototype.getDoors = function() {
				return this._doors;
			};
			Truck.prototype.toString = function() {
				var truck = Automobile.prototype.toString.call(this);

				truck += ",numberOfDoors=" + this.getDoors();
				return truck;
			};
			return Truck;
		})();

		var Limo = (function() {
			function Limo(brand, age, wheels, consumption, fuel) {
				if (wheels == undefined) {
					wheels = "4";
				}
				Automobile.call(this, brand, age, "road", wheels, consumption, fuel);
				this._emloyes = [];
			}

			Limo.extend(Automobile);
			Limo.prototype.appendEmployee = function(employee) {
				var index = this._emloyes.indexOf(employee);
				if (index < 0) {

					this._emloyes.push(employee);
				}
			};
			Limo.prototype.detachEmployee = function(employee) {
				var index = this._emloyes.indexOf(employee);
				if (index < 0) {
					throw new Error();
				}
				this._emloyes.splice(index, 1);
			};
			Limo.getEmployees = function() {
				return this._emloyes;
			};

			Limo.prototype.toString = function() {
				var automobile = Automobile.prototype.toString.call(this);
				automobile += "\n" + " --> Employees, allowed to drive:";
				if (this._emloyes.length == 0) {
					automobile += " ---";
				}

				for (var i = 0; i < this._emloyes.length; i++) {
					automobile += "\n" + this._emloyes[i].toString();
				}
				return automobile;
			};
			return Limo;
		})();

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
