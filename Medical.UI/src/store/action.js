export const getRecruitmentCreationDropDown = async () => {
    try {
        const response = await RecruitmentCreationRequest.getRecruitmentCreationDropDown();
        if (response.data.success === false) {
            return false;
        }
        else {
            return response.data;
        }
    }
    catch (e) {
        console.log(e);
        return false;
    }
}
