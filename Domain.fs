namespace OrderTakingDDD.Domain

type Undefined = exn

type WidgetCode = WidgetCode of string
type GizmoCode = GizmoCode of string

type ProductCode =
    | Widget of WidgetCode
    | Gizmo of GizmoCode

type UnitQuantity = UnitQuantity of int
type KilogramQuantity = KilogramQuantity of decimal
type OrderQuantity =
    | Unit of UnitQuantity
    | Kilos of KilogramQuantity

type OrderId = Undefined
type OrderLineId = Undefined
type CustomerId = Undefined

type CustomerInfo = Undefined
type ShippingAddress = Undefined
type BillingAddress = Undefined
type Price = Undefined
type BillingAmount = Undefined

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
