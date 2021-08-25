import medicalApi from './MedicalApi'
const ENDPOINT = '/api/User/'

export default {
    AuthenticateUser (userDetails) {
        return medicalApi.post(`${ENDPOINT}AuthenticateUser`, userDetails, { headers: { 'content-type': 'application/json' } })
    },
    // AuthenticateUser() {
    //     return medicalApi.get(`${ENDPOINT}GetRecruitmentRequest`);
    // },

    // getRecruitmentRequestDetails(rrId) {
    //     return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequestDetails?RRId=${rrId}`);

    // },
    // deleteRecruitmentRequest(RRId, userId) {
    //     return recruitmentApi.put(`${ENDPOINT}DeleteRecruitmentRequest?RRId=${RRId}&userId=${userId}`)
    // },

    // updateRecruitmentRequest(recruitmentRequest) {
    //     return recruitmentApi.put(`${ENDPOINT}UpdateRecruitmentRequest`, recruitmentRequest, { headers: { 'content-type': 'application/json' } });
    // },
    // AuthenticateUser() {
    //     return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequestsForHRManager`);
    // },
    // getRecruitmentCreationDropDown() {
    //     return recruitmentApi.get(`${ENDPOINT}GetRecruitmentMasterData`);
    // },
    // GetRecruitmentRequestsByID(userId, isHrManager) {
    //     return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequestsByID?userId=${userId}&isHrManager=${isHrManager}`);
    // },
}
