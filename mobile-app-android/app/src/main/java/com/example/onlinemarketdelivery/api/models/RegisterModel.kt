package com.example.onlinemarketdelivery.api.models

data class RegisterModel(
    val userName: String?,
    val emailAddress: String?,
    val password: String?,
    val appName: String?,
)

data class RegisterResult(
    val tenantId: String?,
)