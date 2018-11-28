namespace OrderTakingDDD.Domain

module Domain =


    type Order = {
        Id: OrderId
        CustomerId: CustomerId
        ShippingAddress: ShippingAddress
        BillingAddress: BillingAddress
        OrderLines: OrderLine list
        AmmountToBill: BillingAmount
    }
    and OrderLine = {
        Id: OrderLineId
        OrderId: OrderId
        ProductCode: ProductCode
        OrderQuantity: OrderQuantity
        Price: Price
    }

    type UnvalidatedOrder = {
        OrderId: string
        CustomerInfo: CustomerInfo
        ShippingAddress: ShippingAddress
    }

    type PlaceOrderEvents = {
        AcknowledgmentSent: Undefined
        OrderPlaced: Undefined
        BillableOrderPlaced: Undefined
    }

    type PlaceOrderError =
        | ValidationError of ValidationError list
    and ValidationError = {
        FieldName: string
        ErrorDescription: string
    }

    type PlaceOrder =
        UnvalidatedOrder -> Result<PlaceOrderEvents, PlaceOrderError>

    module UnitQuantity =
        let create qty =

