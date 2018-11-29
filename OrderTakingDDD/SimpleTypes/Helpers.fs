namespace OrderTakingDDD.SimpleTypes

module Helpers =
    module ConstrainedType =
        open System

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
        
        let createLike fieldName ctor pattern s =
            if String.IsNullOrEmpty(s) then
                let msg = sprintf "%s: Must not be null or empty" fieldName
                Error msg
            elif System.Text.RegularExpressions.Regex.IsMatch(s, pattern) then
                Ok (ctor s)
            else
                let msg = sprintf "%s: '%s' must match the pattern '%s'" fieldName s pattern
                Error msg




