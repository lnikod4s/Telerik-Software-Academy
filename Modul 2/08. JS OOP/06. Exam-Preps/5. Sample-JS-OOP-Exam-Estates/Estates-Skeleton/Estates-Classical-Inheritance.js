function processEstatesAgencyCommands(commands) {

	'use strict';

	// -------------------------- Helper Functions --------------------------
	Object.prototype.extend = function(parent) {
		this.prototype = Object.create(parent.prototype);
		this.prototype.constructor = this;
	};
	
	function compare(a, b) {
		if (a > b) {
			return +1;
		}

		if (a < b) {
			return -1
		}

		return 0;
	}

	function isInteger(value) {
		return typeof value === "number" &&
		       isFinite(value) &&
		       Math.floor(value) === value;
	}

	var CommonValidator = {
		validateString: function(string) {
			return typeof string === 'string' && string.length;
		},
		validateArea: function(number) {
			var MIN_VALUE = 1,
				MAX_VALUE = 10000;

			return isInteger(number) && (number >= MIN_VALUE && number <= MAX_VALUE);
		},
		validateRooms: function(number) {
			var MIN_VALUE = 1,
				MAX_VALUE = 100;

			return isInteger(number) && (number >= MIN_VALUE && number <= MAX_VALUE);
		},
		validateFloors: function(number) {
			var MIN_VALUE = 1,
				MAX_VALUE = 10;

			return isInteger(number) && (number >= MIN_VALUE && number <= MAX_VALUE);
		},
		validateDimensions: function(number) {
			var MIN_VALUE = 1,
				MAX_VALUE = 500;

			return isInteger(number) && (number >= MIN_VALUE && number <= MAX_VALUE);
		},
		validatePrice: function(number) {
			return isInteger(number) && number > 0;
		}
	};
	// **********************************************************************

	var Estate = (function() {
		function Estate(name, area, location, isFurnitured) {
			if (this.constructor === Estate) {
				throw new Error("Can't instantiate abstract class Estate.");
			}

			this.setName(name);
			this.setArea(area);
			this.setLocation(location);
			this.setIsFurnitured(isFurnitured);
		}

		Estate.prototype.getName = function() {
			return this._name;
		};

		Estate.prototype.setName = function(name) {
			if (!CommonValidator.validateString(name)) {
				throw new Error('Invalid name.');
			}
			
			this._name = name;
		};

		Estate.prototype.getArea = function() {
			return this._area;
		};

		Estate.prototype.setArea = function(area) {
			if (!CommonValidator.validateArea(area)) {
				throw new Error('Invalid area.');
			}

			this._area = area;
		};

		Estate.prototype.getLocation = function() {
			return this._location;
		};

		Estate.prototype.setLocation = function(location) {
			if (!CommonValidator.validateString(location)) {
				throw new Error('Invalid location.');
			}

			this._location = location;
		};

		Estate.prototype.getIsFurnitured = function() {
			return this._isFurnitured;
		};

		Estate.prototype.setIsFurnitured = function(isFurnitured) {
			this._isFurnitured = isFurnitured;
		};

		Estate.prototype.toString = function() {
			var hasFurniture = this.getIsFurnitured() ? 'Yes' : 'No';

			return this.constructor.name +
			       ': Name = ' + this.getName() +
			       ', Area = ' + this.getArea() +
			       ', Location = ' + this.getLocation() +
			       ', Furnitured = ' + hasFurniture;
		};

		return Estate;
	}());

	var BuildingEstate = (function() {
		function BuildingEstate(name, area, location, isFurnitured, rooms, hasElevator) {
			if (this.constructor === BuildingEstate) {
				throw new Error("Can't instantiate abstract class BuildingEstate.");
			}

			Estate.call(this, name, area, location, isFurnitured);
			this.setRooms(rooms);
			this.setHasElevator(hasElevator);
		}

		BuildingEstate.extend(Estate);

		BuildingEstate.prototype.getRooms = function() {
			return this._rooms;
		};

		BuildingEstate.prototype.setRooms = function(rooms) {
			if (!CommonValidator.validateRooms(rooms)) {
				throw new Error('Invalid number of rooms.');
			}

			this._rooms = rooms;
		};

		BuildingEstate.prototype.getHasElevator = function() {
			return this._hasElevator;
		};

		BuildingEstate.prototype.setHasElevator = function(hasElevator) {
			this._hasElevator = hasElevator;
		};

		BuildingEstate.prototype.toString = function() {
			var hasElevator,
				superToString;

			hasElevator = this.getHasElevator() ? 'Yes' : 'No';
			superToString = Estate.prototype.toString.call(this);

			return superToString +
			       ', Rooms: ' + this.getRooms() +
			       ', Elevator: ' + hasElevator;
		};

		return BuildingEstate;
	}());

	var Apartment = (function() {
		function Apartment(name, area, location, isFurnitured, rooms, hasElevator) {
			BuildingEstate.call(this, name, area, location, isFurnitured, rooms, hasElevator);
		}

		Apartment.extend(BuildingEstate);

		return Apartment;
	}());

	var Office = (function() {
		function Office(name, area, location, isFurnitured, rooms, hasElevator) {
			BuildingEstate.call(this, name, area, location, isFurnitured, rooms, hasElevator);
		}

		Office.extend(BuildingEstate);

		return Office;
	}());

	var House = (function() {
		function House(name, area, location, isFurnitured, floors) {
			Estate.call(this, name, area, location, isFurnitured);
			this.setFloors(floors);
		}

		House.extend(Estate);

		House.prototype.getFloors = function() {
			return this._floors;
		};

		House.prototype.setFloors = function(floors) {
			if (!CommonValidator.validateFloors(floors)) {
				throw new Error('Invalid number of floors.');
			}

			this._floors = floors;
		};

		House.prototype.toString = function() {
			var superToString = Estate.prototype.toString.call(this);

			return superToString +
			       ', Floors: ' + this.getFloors();
		};

		return House;
	}());

	var Garage = (function() {
		function Garage(name, area, location, isFurnitured, width, height) {
			Estate.call(this, name, area, location, isFurnitured);
			this.setWidth(width);
			this.setHeight(height);
		}

		Garage.extend(Estate);

		Garage.prototype.getWidth = function() {
			return this._width;
		};

		Garage.prototype.setWidth = function(width) {
			if (!CommonValidator.validateDimensions(width)) {
				throw new Error('Invalid width.');
			}

			this._width = width;
		};

		Garage.prototype.getHeight = function() {
			return this._height;
		};

		Garage.prototype.setHeight = function(height) {
			if (!CommonValidator.validateDimensions(height)) {
				throw new Error('Invalid height.');
			}

			this._height = height;
		};

		Garage.prototype.toString = function() {
			var superToString = Estate.prototype.toString.call(this);

			return superToString +
			       ', Width: ' + this.getWidth() +
			       ', Height: ' + this.getHeight();
		};

		return Garage;
	}());

	var Offer = (function() {
		function Offer(estate, price) {
			if (this.constructor === Offer) {
				throw new Error("Can't instantiate abstract class Estate.");
			}

			this.setEstate(estate);
			this.setPrice(price);
		}

		Offer.prototype.getEstate = function() {
			return this._estate;
		};

		Offer.prototype.setEstate = function(estate) {
			this._estate = estate;
		};

		Offer.prototype.getPrice = function() {
			return this._price;
		};

		Offer.prototype.setPrice = function(price) {
			if (!CommonValidator.validatePrice(price)) {
				throw new Error('Invalid price.');
			}

			this._price = price;
		};

		Offer.prototype.toString = function() {
			return 'Estate = ' + this.getEstate().getName() +
			       ', Location = ' + this.getEstate().getLocation() +
			       ', Price = ' + this.getPrice();
		};

		return Offer;
	}());

	var RentOffer = (function() {
		function RentOffer(estate, price) {
			Offer.call(this, estate, price);
		}

		RentOffer.extend(Offer);

		RentOffer.prototype.toString = function() {
			var superToString = Offer.prototype.toString.call(this);

			return 'Rent: ' + superToString;
		};

		return RentOffer;
	}());

	var SaleOffer = (function() {
		function SaleOffer(estate, price) {
			Offer.call(this, estate, price);
		}

		SaleOffer.extend(Offer);

		SaleOffer.prototype.toString = function() {
			var superToString = Offer.prototype.toString.call(this);

			return 'Sale: ' + superToString;
		};

		return SaleOffer;
	}());

	var EstatesEngine = (function() {
		var _estates;
		var _uniqueEstateNames;
		var _offers;

		function initialize() {
			_estates = [];
			_uniqueEstateNames = {};
			_offers = [];
		}

		function executeCommand(command) {
			var cmdParts = command.split(' ');
			var cmdName = cmdParts[0];
			var cmdArgs = cmdParts.splice(1);
			switch (cmdName) {
				case 'create':
					return executeCreateCommand(cmdArgs);
				case 'status':
					return executeStatusCommand();
				case 'find-sales-by-location':
					return executeFindSalesByLocationCommand(cmdArgs[0]);
				case 'find-rents-by-location':
					return executeFindRentsByLocationCommand(cmdArgs[0]);
				case 'find-rents-by-price':
					return executeFindRentsByPriceRangeCommand(
						Number(cmdArgs[0]), Number(cmdArgs[1]));
				default:
					throw new Error('Unknown command: ' + cmdName);
			}
		}

		function executeCreateCommand(cmdArgs) {
			var objType = cmdArgs[0];
			switch (objType) {
				case 'Apartment':
					var apartment = new Apartment(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
					                              parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
					addEstate(apartment);
					break;
				case 'Office':
					var office = new Office(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
					                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
					addEstate(office);
					break;
				case 'House':
					var house = new House(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
					                      parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
					addEstate(house);
					break;
				case 'Garage':
					var garage = new Garage(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
					                        parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
					addEstate(garage);
					break;
				case 'RentOffer':
					var estate = findEstateByName(cmdArgs[1]);
					var rentOffer = new RentOffer(estate, Number(cmdArgs[2]));
					addOffer(rentOffer);
					break;
				case 'SaleOffer':
					estate = findEstateByName(cmdArgs[1]);
					var saleOffer = new SaleOffer(estate, Number(cmdArgs[2]));
					addOffer(saleOffer);
					break;
				default:
					throw new Error('Unknown object to create: ' + objType);
			}
			return objType + ' created.';
		}

		function parseBoolean(value) {
			switch (value) {
				case "true":
					return true;
				case "false":
					return false;
				default:
					throw new Error("Invalid boolean value: " + value);
			}
		}

		function findEstateByName(estateName) {
			for (var i = 0; i < _estates.length; i++) {
				if (_estates[i].getName() == estateName) {
					return _estates[i];
				}
			}
			return undefined;
		}

		function addEstate(estate) {
			if (_uniqueEstateNames[estate.getName()]) {
				throw new Error('Duplicated estate name: ' + estate.getName());
			}
			_uniqueEstateNames[estate.getName()] = true;
			_estates.push(estate);
		}

		function addOffer(offer) {
			_offers.push(offer);
		}

		function executeStatusCommand() {
			var result = '', i;
			if (_estates.length > 0) {
				result += 'Estates:\n';
				for (i = 0; i < _estates.length; i++) {
					result += "  " + _estates[i].toString() + '\n';
				}
			} else {
				result += 'No estates\n';
			}

			if (_offers.length > 0) {
				result += 'Offers:\n';
				for (i = 0; i < _offers.length; i++) {
					result += "  " + _offers[i].toString() + '\n';
				}
			} else {
				result += 'No offers\n';
			}

			return result.trim();
		}

		function executeFindSalesByLocationCommand(location) {
			return findOffersByLocation(location, SaleOffer);
		}

		function executeFindRentsByLocationCommand(location) {
			return findOffersByLocation(location, RentOffer);
		}

		function executeFindRentsByPriceRangeCommand(minPrice, maxPrice) {
			if (!isInteger(minPrice) || !isInteger(maxPrice)) {
				throw new Error("Invalid price range.");
			}
			// Select all rent offers within the price range
			var selectedOffers = _offers.filter(function(offer) {
				return offer.getPrice() >= minPrice &&
				       offer.getPrice() <= maxPrice &&
				       offer instanceof RentOffer;
			});

			// Sort selected offers by name
			selectedOffers.sort(function(a, b) {
				return a.getEstate().getName().localeCompare(b.getEstate().getName());
			});

			// Sort the sorted by name offers by price
			selectedOffers.sort(function(a, b) {
				return a.getPrice() - b.getPrice();
			});

			return formatQueryResults(selectedOffers);
		}

		function findOffersByLocation(location, offerClass) {
			if (!location) {
				throw new Error("Location cannot be empty.");
			}
			var selectedOffers = _offers.filter(function(offer) {
				return offer.getEstate().getLocation() === location &&
				       offer instanceof offerClass;
			});
			selectedOffers.sort(function(a, b) {
				return a.getEstate().getName().localeCompare(b.getEstate().getName());
			});
			return formatQueryResults(selectedOffers);
		}

		function formatQueryResults(offers) {
			var result = '';
			if (offers.length == 0) {
				result += 'No Results\n';
			} else {
				result += 'Query Results:\n';
				for (var i = 0; i < offers.length; i++) {
					var offer = offers[i];
					result += '  [Estate: ' + offer.getEstate().getName() +
					          ', Location: ' + offer.getEstate().getLocation() +
					          ', Price: ' + offer.getPrice() + ']\n';
				}
			}
			return result.trim();
		}

		return {
			initialize: initialize,
			executeCommand: executeCommand
		};
	}());

	// Process the input commands and return the results
	var results = '';
	EstatesEngine.initialize();
	commands.forEach(function(cmd) {
		if (cmd != '') {
			try {
				var cmdResult = EstatesEngine.executeCommand(cmd);
				results += cmdResult + '\n';
			}
			catch (err) {
				//console.log(err);
				results += 'Invalid command.\n';
			}
		}
	});
	return results.trim();

}