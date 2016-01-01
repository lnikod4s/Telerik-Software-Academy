var amazon = amazon || {};

(function (amazon) {
	var users = [];
	var categories = [];
	var items = [];

	function generateData() {
		var categoryBooks,
			categoryElectronics,
			categoryComputers,
			categoryComputersPersonal,
			categoryComputersLaptops,
		    item1, item2, item3, item4, item5,
			item6, item7, item8, item9, item10,
			item11, item12, item13, item14, item15,
			item15, item16, item17, item18, item19,
		    userPesho, userGosho, userVlado;

		// Generate categories
		categoryBooks = models.getCategory('Books');
		categoryElectronics = models.getCategory('Electronics');
		categoryComputers = models.getCategory('Computers');
		categoryComputersLaptops = models.getCategory('Laptops');
		categoryComputersTablets = models.getCategory('Tablets');
		categoryComputers.addCategory(categoryComputersLaptops);
		categoryComputers.addCategory(categoryComputersTablets);

		categories = [categoryBooks, categoryComputers, categoryElectronics];

		// Load books
		item1 = models.getItem('JavaScript Basics', 'Some description', 10);
		item2 = models.getItem('JavaScript Design Patterns', 'Some description', 15);
		item3 = models.getItem('JavaScript: The Good Parts', 'Some description', 14.30);
		item4 = models.getItem('Learning JavaScript', 'Some description', 25.40);
		item5 = models.getItem('JavaScript Testing with Jasmine', 'Some description', 40.20);
		categoryBooks.addItem(item1);
		categoryBooks.addItem(item2);
		categoryBooks.addItem(item3);
		categoryBooks.addItem(item4);
		categoryBooks.addItem(item5);

		// Load electornics
		item6 = models.getItem('PowerLite Home Cidema 5030', 'Some description', 1200);
		item7 = models.getItem('Samsung Gear 2', 'Some description', 1121);
		item8 = models.getItem('Canon 60D', 'Some description', 1501);
		item9 = models.getItem('Sony STRDH740', 'Some description', 2312);
		item10 = models.getItem('HTC One M9', 'Some description', 1121);
		categoryElectronics.addItem(item6);
		categoryElectronics.addItem(item7);
		categoryElectronics.addItem(item8);
		categoryElectronics.addItem(item9);
		categoryElectronics.addItem(item10);

		// Load laptops
		item11 = models.getItem('Dell Inspiron 5545', 'Some description', 1300);
		item12 = models.getItem('Asus Transformer Book', 'Some description', 1400);
		item13 = models.getItem('Toshiba Satellite C50-B-158', 'Some description', 1290);
		item14 = models.getItem('Apple MacBook Air', 'Some description', 1321);
		item15 = models.getItem('Acer Aspire', 'Some description', 1423);
		categoryComputersLaptops.addItem(item11);
		categoryComputersLaptops.addItem(item12);
		categoryComputersLaptops.addItem(item13);
		categoryComputersLaptops.addItem(item14);
		categoryComputersLaptops.addItem(item15);

		// Load tablets
		item16 = models.getItem('Prestigio Multipad', 'Some description', 802);
		item17 = models.getItem('iPad Air 2', 'Some description', 793);
		item18 = models.getItem('Asus fonepad', 'Some description', 640);
		item19 = models.getItem('Acer Iconia Tab 8', 'Some description', 594);
		item20 = models.getItem('Lenovo Tab 2 A7-10', 'Some description', 843);
		categoryComputersTablets.addItem(item16);
		categoryComputersTablets.addItem(item17);
		categoryComputersTablets.addItem(item18);
		categoryComputersTablets.addItem(item19);
		categoryComputersTablets.addItem(item20);

		items = [
			item1, item2, item3, item4, item5, 
			item6, item7, item8, item9, item10, 
			item11, item12, item13, item14, item15, 
			item16, item17, item18, item19, item20
		];

		// Load customer reviews
		items.forEach(function (item, index) {
			var random,
				customer,
				content,
				rating,
				startDate,
				endDate,
				createdOn,
				customerReview;

			for (var i = 0; i < 5; i++) {
				random = (index + 1) * 3 / Math.random();
				customer = 'Customer ' + random
				content = 'Content bqlvlqbl ' + random;
				rating = Math.random() * 10;
				startDate = new Date(1999, 1, 1);
				endDate = new Date(2015, 12, 12);
				createdOn = new Date(startDate.getTime() + Math.random() * (endDate.getTime() - startDate.getTime()));;
				customerReview = models.getCustomerReview(customer, content, rating, createdOn);
				item.addCustomerReview(customerReview);
			};
		});

		// Load users
		userPesho = models.getUser('PeshoKirkata', 'Peter Petrov Manolov', 1230);
		userGosho = models.getUser('GoshoStyklarq', 'George Markov Grozdev', 540);
		userVlado = models.getUser('VladoMotikata', 'Vladimir Torbeev Tarambukov', 2401);

		// Add items to user carts
		userPesho.addItemToCart(item3);
		userPesho.addItemToCart(item5);
		userPesho.addItemToCart(item7);

		userGosho.addItemToCart(item12);
		userGosho.addItemToCart(item6);

		userVlado.addItemToCart(item9);
		userVlado.addItemToCart(item18);

		users = [userPesho, userGosho, userVlado];
	}

	function getCategories() {
		return categories;
	}

	function getUsers() {
		return users;
	}

	amazon.generateData = generateData;
	amazon.getCategories = getCategories;
	amazon.getUsers = getUsers;
}(amazon));