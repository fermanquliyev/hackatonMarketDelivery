package com.example.onlinemarketdelivery.api

import com.example.onlinemarketdelivery.api.models.RegisterModel
import com.example.onlinemarketdelivery.api.models.RegisterResult
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface DeliveryService {
        @POST("/api/account/register")
        fun register(@Body() registerModel: RegisterModel): Call<RegisterResult>
}