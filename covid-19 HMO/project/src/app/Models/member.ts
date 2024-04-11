export class Member {
    id!: number
    name!: string
    idNumber!: string
    cityId!: number
    street!: string
    houseNumber!: number
    birthDate!: Date
    phone!: string
    mobilePhone?: string
    dateOfSickness?: Date
    dateOfRecovery?: Date
    imageUrl?: string
    image?: File 
}
