import recruitmentApi from "./RecruitmentApi";
const ENDPOINT = '/api/RecruitmentRequest/';

export default {
    saveRecruitmentCreation(recruitmentRequest) {
        return recruitmentApi.post(`${ENDPOINT}CreateRecruitmentRequest`, recruitmentRequest, { headers: { 'content-type': 'application/json' } });
    },
    getListRecruitmentRequest() {
        return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequest`);
    },

    getRecruitmentRequestDetails(rrId) {
        return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequestDetails?RRId=${rrId}`);

    },
    deleteRecruitmentRequest(RRId, userId) {
        return recruitmentApi.put(`${ENDPOINT}DeleteRecruitmentRequest?RRId=${RRId}&userId=${userId}`)
    },

    updateRecruitmentRequest(recruitmentRequest) {
        return recruitmentApi.put(`${ENDPOINT}UpdateRecruitmentRequest`, recruitmentRequest, { headers: { 'content-type': 'application/json' } });
    },
    getListRecruitmentRequestForHRManger() {
        return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequestsForHRManager`);
    },
    getRecruitmentCreationDropDown() {
        return recruitmentApi.get(`${ENDPOINT}GetRecruitmentMasterData`);
    },
    GetRecruitmentRequestsByID(userId, isHrManager) {
        return recruitmentApi.get(`${ENDPOINT}GetRecruitmentRequestsByID?userId=${userId}&isHrManager=${isHrManager}`);
    },
}
