namespace OrderTakingDDD.SimpleTypes

open Helpers

module Common =

    type Undefined = exn

    type WidgetCode = private WidgetCode of string
    type GizmoCode = private GizmoCode of string

    type ProductCode =
        | Widget of WidgetCode
        | Gizmo of GizmoCode


    type UnitQuantity = private UnitQuantity of int
    type KilogramQuantity = private KilogramQuantity of decimal
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


    module UnitQuantity  =
        let value (UnitQuantity v) = v

        let create fieldName v = 
            ConstrainedType.createInt fieldName UnitQuantity 1 1000 v
    
    module KilogramQuantity =
        let value (KilogramQuantity v) = v

        let create fieldName v =
            ConstrainedType.createDecimal fieldName KilogramQuantity 0.5M 100M v
    
    module WidgetCode = 
        let value (WidgetCode code) = code 
        
        let create fieldName code =
            let pattern = "W\d{4}$"
            ConstrainedType.createLike fieldName WidgetCode pattern code

    module GizmoCode = 
        let value (GizmoCode code) = code 
        
        let create fieldName code =
            let pattern = "G\d{3}$"
            ConstrainedType.createLike fieldName GizmoCode pattern code