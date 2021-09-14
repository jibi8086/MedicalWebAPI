import medicalApi from './MedicalApi'
const ENDPOINT = '/api/Company/'
export default {
    CreateCompany (companyDetails) {
        return medicalApi.post(`${ENDPOINT}RegisterCompany`, companyDetails, { headers: { 'content-type': 'application/json' } })
    },
        GetCompanyDetails () {
        return medicalApi.get(`${ENDPOINT}GetAllCompanyDetails`)
    },
}
