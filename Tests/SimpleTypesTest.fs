namespace Tests

open NUnit.Framework
open FsUnit
open OrderTakingDDD.SimpleTypes.Common


[<SimpleTypesTest>]
type SimpleTypesTest () =

    [<Test>]
    member x.``WidgetCode should return : Must not be null or empty if input is empty string``() =
        // SETUP
        let sampleWidgetCode = 
            match (WidgetCode.create "sampleWidgetCode" "") with
            | Ok _ -> ""
            | Error err -> err 


        sampleWidgetCode |> should equal "sampleWidgetCode: Must not be null or empty"

    [<Test>]
    member x.``WidgetCode with code W1234 should return "W1234"``() =
        // SETUP
        let sampleWidgetCode = 
            match (WidgetCode.create "sampleWidgetCode" "W1234") with
            | Ok code -> WidgetCode.value(code)
            | Error err ->  err 


        sampleWidgetCode |> should equal "W1234"


    [<Test>]
    member x.``WidgetCode with code W123 should return "sampleWidgetCode: 'W123' must match the pattern 'W\d{4}'"``() =
        // SETUP
        let sampleWidgetCode = 
            match (WidgetCode.create "sampleWidgetCode" "W123") with
            | Ok code -> WidgetCode.value(code)
            | Error err -> err 


        sampleWidgetCode |> should equal "sampleWidgetCode: 'W123' must match the pattern 'W\\d{4}$'"

    // GizmoCode Tests

    [<Test>]
    member x.``GizmoCode should return : Must not be null or empty if input is empty string``() =
        // SETUP
        let sampleGizmoCode = 
            match (GizmoCode.create "sampleGizmoCode" "") with
            | Ok _ -> ""
            | Error err -> err 


        sampleGizmoCode |> should equal "sampleGizmoCode: Must not be null or empty"

    [<Test>]
    member x.``GizmoCode with code G123 should return "G123"``() =
        // SETUP
        let sampleGizmoCode = 
            match (GizmoCode.create "sampleGizmoCode" "G123") with
            | Ok code -> GizmoCode.value(code)
            | Error err ->  err 


        sampleGizmoCode |> should equal "G123"


    [<Test>]
    member x.``GizmoCode with code G123 should return "sampleGizmoCode: 'G123' must match the pattern 'G\d{3}'"``() =
        // SETUP
        let sampleGizmoCode = 
            match (GizmoCode.create "sampleGizmoCode" "G1234") with
            | Ok code -> GizmoCode.value(code)
            | Error err ->  err 


        sampleGizmoCode |> should equal "sampleGizmoCode: 'G1234' must match the pattern 'G\\d{3}$'"

    // UnitQuantity Tests
    [<Test>]
    member x.``UnitQuantity value must not be less than 1"``() =
        // SETUP
        let sampleUnitQuantity = 
            match (UnitQuantity.create "sampleUnitQuantity" -5) with
            | Ok v -> UnitQuantity.value(v).ToString()
            | Error err ->  err


        sampleUnitQuantity |> should equal "sampleUnitQuantity: Must not be less than 1"
    
     [<Test>]
     member x.``UnitQuantity value must not be greater than 1000"``() =
        // SETUP
        let sampleUnitQuantity = 
            match (UnitQuantity.create "sampleUnitQuantity" 1001) with
            | Ok v -> UnitQuantity.value(v).ToString()
            | Error err ->  err


        sampleUnitQuantity |> should equal "sampleUnitQuantity: Must not be greater than 1000"

     [<Test>]
     member x.``UnitQuantity value must be equal 11"``() =
        // SETUP
        let sampleUnitQuantity = 
            match (UnitQuantity.create "sampleUnitQuantity" 11) with
            | Ok v -> UnitQuantity.value(v).ToString()
            | Error err ->  err


        sampleUnitQuantity |> should equal "11"



    // KilogramQuantity Tests 0.5M 100M
    [<Test>]
    member x.``KilogramQuantity value must not be less than 0,5"``() =
        // SETUP
        let sampleKilogramQuantity = 
            match (KilogramQuantity.create "sampleKilogramQuantity" 0.1M) with
            | Ok v -> KilogramQuantity.value(v).ToString()
            | Error err ->  err


        sampleKilogramQuantity |> should equal "sampleKilogramQuantity: Must not be less than 0.5"
    
     [<Test>]
     member x.``KilogramQuantity value must not be greater than 100"``() =
        // SETUP
        let sampleKilogramQuantity = 
            match (KilogramQuantity.create "sampleKilogramQuantity" 101M) with
            | Ok v -> KilogramQuantity.value(v).ToString()
            | Error err ->  err


        sampleKilogramQuantity |> should equal "sampleKilogramQuantity: Must not be greater than 100"

     [<Test>]
     member x.``KilogramQuantity value must be equal 17.45"``() =
        // SETUP
        let sampleUnitQuantity = 
            match (KilogramQuantity.create "sampleKilogramQuantity" 17.45M) with
            | Ok v -> KilogramQuantity.value(v)
            | Error _ ->  0M


        sampleUnitQuantity |> should equal  17.45M

     // OdrerId Tests 
     [<Test>]
     member x.``OdrerId must not to be empty"``() =
        // SETUP
        let sampleOdrerId = 
            match (OdrerId.create "sampleOdrerId" "") with
                | Ok v -> OdrerId.value(v)
                | Error err -> err 
        
        sampleOdrerId |> should equal "sampleOdrerId: must not be null or empty"

     [<Test>]
     member x.``OdrerId length must not be greater than 50"``() =
        // SETUP
        let sampleOdrerId1 = 
            match (OdrerId.create "sampleOdrerId1" "Praesent in mauris eu tortor porttitor accumsan Mauris suscipit") with
                | Ok v -> OdrerId.value(v)
                | Error err -> err 
        
        let sampleOdrerId2 = 
            match (OdrerId.create "sampleOdrerId2" "Praesent in mauris eu tortor porttitor accumsan Mxx") with
                | Ok v -> OdrerId.value(v)
                | Error err -> err 

        System.Console.WriteLine(sampleOdrerId2.Length.ToString())
        
        sampleOdrerId1 |> should equal "sampleOdrerId1: must not be more than 50 chars"
        sampleOdrerId2 |> should equal "sampleOdrerId2: must not be more than 50 chars"

     [<Test>]
     member x.``OdrerId should return value"``() =
        // SETUP
        let sampleOdrerId1 = 
            match (OdrerId.create "sampleOdrerId1" "id23") with
                | Ok v -> OdrerId.value(v)
                | Error err -> err 
        let sampleOdrerId2 = 
            match (OdrerId.create "sampleOdrerId2" "Praesent in mauris eu tortor porttitor accumsan Mx") with
                | Ok v -> OdrerId.value(v)
                | Error err -> err 
        
        sampleOdrerId1 |> should equal "id23"
        sampleOdrerId2 |> should equal "Praesent in mauris eu tortor porttitor accumsan Mx"      

      // OrderLineId Tests 
     [<Test>]
     member x.``OrderLineId must not to be empty"``() =
        // SETUP
        let sampleOrderLineId = 
            match (OrderLineId.create "sampleOrderLineId" "") with
                | Ok v -> OrderLineId.value(v)
                | Error err -> err 
        
        sampleOrderLineId |> should equal "sampleOrderLineId: must not be null or empty"

     [<Test>]
     member x.``OrderLineId length must not be greater than 50"``() =
        // SETUP
        let sampleOrderLineId1 = 
            match (OrderLineId.create "sampleOrderLineId1" "Praesent in mauris eu tortor porttitor accumsan Mauris suscipit") with
                | Ok v -> OrderLineId.value(v)
                | Error err -> err 
        
        let sampleOrderLineId2 = 
            match (OrderLineId.create "sampleOrderLineId2" "Praesent in mauris eu tortor porttitor accumsan Mxx") with
                | Ok v -> OrderLineId.value(v)
                | Error err -> err 

        System.Console.WriteLine(sampleOrderLineId2.Length.ToString())
        
        sampleOrderLineId1 |> should equal "sampleOrderLineId1: must not be more than 50 chars"
        sampleOrderLineId2 |> should equal "sampleOrderLineId2: must not be more than 50 chars"

     [<Test>]
     member x.``OrderLineId should return value"``() =
        // SETUP
        let sampleOrderLineId1 = 
            match (OrderLineId.create "sampleOrderLineId1" "id23") with
                | Ok v -> OrderLineId.value(v)
                | Error err -> err 
        let sampleOrderLineId2 = 
            match (OrderLineId.create "sampleOrderLineId2" "Praesent in mauris eu tortor porttitor accumsan Mx") with
                | Ok v -> OrderLineId.value(v)
                | Error err -> err 
        
        sampleOrderLineId1 |> should equal "id23"
        sampleOrderLineId2 |> should equal "Praesent in mauris eu tortor porttitor accumsan Mx"      