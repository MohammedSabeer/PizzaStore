using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStore.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql(
           @"
                INSERT INTO Products VALUES('Margherita','Classic delight with 100% real mozzarella cheese',239)
                INSERT INTO Products VALUES('Farmhouse','Delightful combination of onion, capsicum, tomato & grilled mushroom',459)
                INSERT INTO Products VALUES('Peppy Paneer','Flavorful trio of juicy paneer, crisp capsicum with spicy red paprika',459)
                INSERT INTO Products VALUES('Veg Extravaganza','Black olives, capsicum, onion, grilled mushroom, corn, tomato, jalapeno & extra cheese',549)
                INSERT INTO Products VALUES('Veggie Paradise','The awesome foursome! Golden corn, black olives, capsicum, red paprika',459)
                INSERT INTO Products VALUES('Cheese n Corn','A delectable combination of sweet & juicy golden corn',379)
                INSERT INTO Products VALUES('Pepper Barbecue Chicken','Pepper barbecue chicken for that extra zing',449)
                INSERT INTO Products VALUES('Chicken Sausage','American classic! Spicy, herbed chicken sausage on pizza',369)
                INSERT INTO Products VALUES('Spicy Barbecue Chicken','Spicy barbecue chicken for that extra zing',500)


                INSERT INTO Toppings VALUES('Cheese',20)
                INSERT INTO Toppings VALUES('Pepper',10)
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
