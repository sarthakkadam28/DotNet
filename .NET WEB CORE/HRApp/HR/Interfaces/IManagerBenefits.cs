using HRAPP.HR.interfaces;

namespace HRAPP.HR;
public interface IManagerBenefits:IAppraisable,IBonusEligible
{
      void Approveleave();
}