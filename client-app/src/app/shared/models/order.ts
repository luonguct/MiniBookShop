export class OrderToCreate {
    basketId: string;
    firstName: string;
    lastName: string;
    street: string;
    city: string;
    state: string;
    zipcode: string;
}

export class UserOrder {
    orderId: number;
    orderDate: string;
    total: number;
    status: string 
}

export class UserOrderDetail {
    orderId: number;
    orderDate: string;
    firstName: string;
    lastName: string;
    phoneNumber: number;
    address: string;
    province: string;
    zipcode: string;
    total: number;
    status: string;
    orderItems: UserOrderItemDetail[];
}


export interface UserOrderItemDetail {
    bookId: number;
    bookTitle: string;
    imageUrl: string;
    price: number;
    quantity: number;
}

