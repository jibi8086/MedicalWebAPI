import medical from '../apis/MedicalApiRequest'
import company from '../apis/CompanyApiRequest'

export const AuthenticateUser = async ({ commit }, userDetails) => {
    try {
        console.log(userDetails)
        const response = await medical.AuthenticateUser(userDetails)
        if (response.data.success === false) {
            return false
        } else {
            return response.data
        }
    } catch (e) {
        console.log(e)
        return false
    }
}

export const CreateCompany = async ({ commit }, userDetails) => {
    try {
        console.log(userDetails)
        const response = await company.CreateCompany(userDetails)
        if (response.data.success === false) {
            return false
        } else {
            return response.data
        }
    } catch (e) {
        console.log(e)
        return false
    }
}

export const GetCompanyDetails = async () => {
    try {
        const response = await company.GetCompanyDetails()
        if (response.data.success === false) {
            return false
        } else {
            return response.data
        }
    } catch (e) {
        console.log(e)
        return false
    }
}
