namespace DristorApp.Data.Models
{
    public class ProductVariant
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public string Unit { set; get; }
        public float Price { set; get; }

        public virtual Product Product { set; get; }
        public virtual ICollection<CartItem> CartItems { set; get; }
        public virtual ICollection<OrderItem> OrderItems { set; get; }
    }
}
/*
 
PRODUCTs
[
  {
    "id": 1,
    "name": "Kabab",
    "ingredients": null,
    "productVariants": null
  },
  {
    "id": 2,
    "name": "Shaorma",
    "ingredients": null,
    "productVariants": null
  },
  {
    "id": 3,
    "name": "Supa cu fructe de mare",
    "ingredients": null,
    "productVariants": null
  },
  {
    "id": 4,
    "name": "Supa cu pui",
    "ingredients": null,
    "productVariants": null
  },
  {
    "id": 5,
    "name": "Pizza",
    "ingredients": null,
    "productVariants": null
  }
]


PRODUCT VARIANTS
[
  {
    "id": 1,
    "name": "Pizza duplate",
    "quantity": 2,
    "unit": "Felie",
    "price": 40,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 2,
    "name": "Supa cu fructe de mare Italiana",
    "quantity": 1,
    "unit": "Bol",
    "price": 50,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 3,
    "name": "Pizza margareta",
    "quantity": 10,
    "unit": "Felie",
    "price": 45,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 4,
    "name": "Kabab nou",
    "quantity": 2,
    "unit": "Kg",
    "price": 38,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 5,
    "name": "Kabab Libanez",
    "quantity": 2,
    "unit": "Kg",
    "price": 45,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 6,
    "name": "Supa cu pui",
    "quantity": 1,
    "unit": "Bol",
    "price": 20,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 7,
    "name": "Shaorma mare",
    "quantity": 1,
    "unit": "Farfurie",
    "price": 50,
    "product": null,
    "cartItems": null,
    "orderItems": null
  },
  {
    "id": 8,
    "name": "Shaorma mare speciala",
    "quantity": 4,
    "unit": "Farfurie",
    "price": 60,
    "product": null,
    "cartItems": null,
    "orderItems": null
  }
]




[
  {
    "id": 1,
    "name": "Sare",
    "allergen": true,
    "spicy": false,
    "products": null
  },
  {
    "id": 2,
    "name": "Carne",
    "allergen": false,
    "spicy": false,
    "products": null
  },
  {
    "id": 3,
    "name": "Pui",
    "allergen": false,
    "spicy": false,
    "products": null
  },
  {
    "id": 5,
    "name": "Legume",
    "allergen": false,
    "spicy": false,
    "products": null
  },
  {
    "id": 6,
    "name": "Paine",
    "allergen": true,
    "spicy": false,
    "products": null
  },
  {
    "id": 7,
    "name": "Vin",
    "allergen": true,
    "spicy": false,
    "products": null
  },
  {
    "id": 4,
    "name": "Fructe de mare",
    "allergen": false,
    "spicy": true,
    "products": null
  }
]





{
  "id": 2,
  "email": "nabil.alhfz98@gmail.com",
  "firstName": "nabil",
  "lastName": "alhafez",
  "roles": [
    "Customer"
  ],
  "addresses": [
    3,
    5,
    6,
    7,
    8
  ]
}




OrderItems
[
  {
    "id": 1,
    "quantity": 1,
    "couponId": null,
    "coupon": null,
    "productVariant": null,
    "order": null
  },
  {
    "id": 2,
    "quantity": 2,
    "couponId": null,
    "coupon": null,
    "productVariant": null,
    "order": null
  }
]



[
  {
    "id": 1,
    "address": {
      "id": 3,
      "country": "Romania",
      "city": "Bucuresti",
      "addressLine": "Bulivardul unirii",
      "postalCode": "061071",
      "phoneNumber": "0755178836",
      "user": {
        "firstName": "nabil",
        "lastName": "alhafez",
        "roles": null,
        "tokens": null,
        "addresses": [
          {
            "id": 5,
            "country": "Romania",
            "city": "Brasov",
            "addressLine": "Bulivardul unirii",
            "postalCode": "061071",
            "phoneNumber": "0755178836",
            "orders": [
              {
                "id": 2,
                "orderStatusUpdates": [],
                "orderItems": [
                  {
                    "id": 2,
                    "quantity": 2,
                    "couponId": null,
                    "coupon": null,
                    "productVariant": {
                      "id": 8,
                      "name": "Shaorma mare speciala",
                      "quantity": 4,
                      "unit": "Farfurie",
                      "price": 60,
                      "product": {
                        "id": 4,
                        "name": "Shaorma mare speciala",
                        "ingredients": null,
                        "productVariants": []
                      },
                      "cartItems": null,
                      "orderItems": []
                    }
                  }
                ]
              }
            ]
          }
        ],
        "cartItems": null,
        "coupons": null,
        "id": 2,
        "userName": "nabil.alhfz98@gmail.com",
        "normalizedUserName": "NABIL.ALHFZ98@GMAIL.COM",
        "email": "nabil.alhfz98@gmail.com",
        "normalizedEmail": "NABIL.ALHFZ98@GMAIL.COM",
        "emailConfirmed": false,
        "passwordHash": "AQAAAAIAAYagAAAAEI8K0bGeMWBqbSKdMPXF2sWjUFJlBtaDMPtGYPnk7/yUsAh/cFMrBsH8WHEuCKL+aQ==",
        "securityStamp": "QCTKFBEU4UBGFE436DX6HZHUKFCNKEIT",
        "concurrencyStamp": "e1406a46-c1a2-4f09-9452-71f4a99322f1",
        "phoneNumber": null,
        "phoneNumberConfirmed": false,
        "twoFactorEnabled": false,
        "lockoutEnd": null,
        "lockoutEnabled": true,
        "accessFailedCount": 0
      },
      "orders": []
    },
    "orderStatusUpdates": [],
    "orderItems": [
      {
        "id": 1,
        "quantity": 1,
        "couponId": null,
        "coupon": null,
        "productVariant": {
          "id": 1,
          "name": "Pizza duplate",
          "quantity": 2,
          "unit": "Felie",
          "price": 40,
          "product": {
            "id": 5,
            "name": "Pizza",
            "ingredients": null,
            "productVariants": []
          },
          "cartItems": null,
          "orderItems": []
        }
      }
    ]
  },
  {
    "id": 2,
    "address": {
      "id": 5,
      "country": "Romania",
      "city": "Brasov",
      "addressLine": "Bulivardul unirii",
      "postalCode": "061071",
      "phoneNumber": "0755178836",
      "user": {
        "firstName": "nabil",
        "lastName": "alhafez",
        "roles": null,
        "tokens": null,
        "addresses": [
          {
            "id": 3,
            "country": "Romania",
            "city": "Bucuresti",
            "addressLine": "Bulivardul unirii",
            "postalCode": "061071",
            "phoneNumber": "0755178836",
            "orders": [
              {
                "id": 1,
                "orderStatusUpdates": [],
                "orderItems": [
                  {
                    "id": 1,
                    "quantity": 1,
                    "couponId": null,
                    "coupon": null,
                    "productVariant": {
                      "id": 1,
                      "name": "Pizza duplate",
                      "quantity": 2,
                      "unit": "Felie",
                      "price": 40,
                      "product": {
                        "id": 5,
                        "name": "Pizza",
                        "ingredients": null,
                        "productVariants": []
                      },
                      "cartItems": null,
                      "orderItems": []
                    }
                  }
                ]
              }
            ]
          }
        ],
        "cartItems": null,
        "coupons": null,
        "id": 2,
        "userName": "nabil.alhfz98@gmail.com",
        "normalizedUserName": "NABIL.ALHFZ98@GMAIL.COM",
        "email": "nabil.alhfz98@gmail.com",
        "normalizedEmail": "NABIL.ALHFZ98@GMAIL.COM",
        "emailConfirmed": false,
        "passwordHash": "AQAAAAIAAYagAAAAEI8K0bGeMWBqbSKdMPXF2sWjUFJlBtaDMPtGYPnk7/yUsAh/cFMrBsH8WHEuCKL+aQ==",
        "securityStamp": "QCTKFBEU4UBGFE436DX6HZHUKFCNKEIT",
        "concurrencyStamp": "e1406a46-c1a2-4f09-9452-71f4a99322f1",
        "phoneNumber": null,
        "phoneNumberConfirmed": false,
        "twoFactorEnabled": false,
        "lockoutEnd": null,
        "lockoutEnabled": true,
        "accessFailedCount": 0
      },
      "orders": []
    },
    "orderStatusUpdates": [],
    "orderItems": [
      {
        "id": 2,
        "quantity": 2,
        "couponId": null,
        "coupon": null,
        "productVariant": {
          "id": 8,
          "name": "Shaorma mare speciala",
          "quantity": 4,
          "unit": "Farfurie",
          "price": 60,
          "product": {
            "id": 4,
            "name": "Shaorma mare speciala",
            "ingredients": null,
            "productVariants": []
          },
          "cartItems": null,
          "orderItems": []
        }
      }
    ]
  }
]
*/