namespace OrderTakingDDD.SimpleTypes

module Helpers =
    module ConstrainedType =
        let createInt fieldName ctor minN maxN n =
            if n < minN then
                let msg = sprintf "%s: Must not be less than %i" fieldName minN
                Error msg
            elif n > maxN then
                let msg = sprintf "%s: Must not be greater than %i" fieldName maxN
                Error msg
            else
                Ok (ctor n)
        
        let createDecimal fieldName ctor minN maxN n =
            if n < minN then
                let msg = sprintf "%s: Must not be less than %M" fieldName minN
                Error msg
            elif n > maxN then
                let msg = sprintf "%s: Must not be greater than %M" fieldName maxN
                Error msg
            else
                Ok (ctor n)

