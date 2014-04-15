using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFillForm
{
   public class StateName
    {
       public static string GetStateName(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo, string stateid, string carid)
       {


           string state = string.Empty;

           if ((obUsedCarsInfo[0].State.ToString() == "PA")||(obUsedCarsInfo[0].State.ToString() == "PA "))
           {
               state = "Pennsylvania";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "TX")||(obUsedCarsInfo[0].State.ToString() == "TX "))
           {
               state = "Texas";
           }
           //else if ((obUsedCarsInfo[0].State.ToString() == "NJ")||(obUsedCarsInfo[0].State.ToString() == "NJ "))
           //{
           //    state = "New Jersey";
           //}
           else if ((obUsedCarsInfo[0].State.ToString() == "AL")||(obUsedCarsInfo[0].State.ToString() == "AL "))
           {
               state = "Alabama";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "AK")||(obUsedCarsInfo[0].State.ToString() == "AK "))
           {
               state = "Alaska";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "AS")||(obUsedCarsInfo[0].State.ToString() == "AS "))
           {
               state = "American Samoa";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "AZ")||(obUsedCarsInfo[0].State.ToString() == "AZ "))
           {
               state = "Arizona";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "AR")||(obUsedCarsInfo[0].State.ToString() == "AR "))
           {
               state = "Arkansas";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "CA")||(obUsedCarsInfo[0].State.ToString() == "CA "))
           {
               state = "California";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "CO")||(obUsedCarsInfo[0].State.ToString() == "CO "))
           {
               state = "Colorado";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "CT")||(obUsedCarsInfo[0].State.ToString() == "CT "))
           {
               state = "Connecticut";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "DE")||(obUsedCarsInfo[0].State.ToString() == "DE "))
           {
               state = "Delaware";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "DC")||(obUsedCarsInfo[0].State.ToString() == "DC "))
           {
               state = "District of Columbia";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "FL")||(obUsedCarsInfo[0].State.ToString() == "FL "))
           {
               state = "Florida";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "GA")||(obUsedCarsInfo[0].State.ToString() == "GA "))
           {
               state = "Georgia";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "GU") || (obUsedCarsInfo[0].State.ToString() == "GU "))
           {
               state = "Guam";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "HI") || (obUsedCarsInfo[0].State.ToString() == "HI "))
           {
               state = "Hawaii";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "IL")||(obUsedCarsInfo[0].State.ToString() == "IL "))
           {
               state = "Illinois";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "IN")||(obUsedCarsInfo[0].State.ToString() == "IN "))
           {
               state = "Indiana";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "IA")||(obUsedCarsInfo[0].State.ToString() == "IA "))
           {
               state = "Iowa";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "KS")||(obUsedCarsInfo[0].State.ToString() == "KS "))
           {
               state = "Kansas";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "KY") || (obUsedCarsInfo[0].State.ToString() == "KY "))
           {
               state = "Kentucky";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "LA") || (obUsedCarsInfo[0].State.ToString() == "LA "))
           {
               state = "Lousiana";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "ME") || (obUsedCarsInfo[0].State.ToString() == "ME "))
           {
               state = "Maine";
           }
           else if((obUsedCarsInfo[0].State.ToString() == "MI")||(obUsedCarsInfo[0].State.ToString() == "MI "))
           {
               state = "Michigan";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "MN") || (obUsedCarsInfo[0].State.ToString() == "MN "))
           {
               state = "Minnesota";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "MS") || (obUsedCarsInfo[0].State.ToString() == "MS "))
           {
               state = "Mississippi";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NJ") || (obUsedCarsInfo[0].State.ToString() == "NJ "))
           {
               state = "New Jersey";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "MO") || (obUsedCarsInfo[0].State.ToString() == "MO "))
           {
               state = "Missouri";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "MT") || (obUsedCarsInfo[0].State.ToString() == "MT "))
           {
               state = "Montana";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NE") || (obUsedCarsInfo[0].State.ToString() == "NE "))
           {
               state = "Nebraska";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NV") || (obUsedCarsInfo[0].State.ToString() == "NV "))
           {
               state = "Nevada";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NH") || (obUsedCarsInfo[0].State.ToString() == "NH "))
           {
               state = "New Hampshire";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NM") || (obUsedCarsInfo[0].State.ToString() == "NM "))
           {
               state = "New Mexico";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NY") || (obUsedCarsInfo[0].State.ToString() == "NY "))
           {
               state = "New York";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "NC") || (obUsedCarsInfo[0].State.ToString() == "NC "))
           {
               state = "North Carolina";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "OH") || (obUsedCarsInfo[0].State.ToString() == "OH "))
           {
               state = "Ohio";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "OK") || (obUsedCarsInfo[0].State.ToString() == "OK "))
           {
               state = "Oklahoma";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "OR") || (obUsedCarsInfo[0].State.ToString() == "OR "))
           {
               state = "Oregon";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "PR") || (obUsedCarsInfo[0].State.ToString() == "PR "))
           {
               state = "Puerto rico";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "RI") || (obUsedCarsInfo[0].State.ToString() == "RI "))
           {
               state = "Rhode Island";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "SC") || (obUsedCarsInfo[0].State.ToString() == "SC "))
           {
               state = "South Carolina";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "SD") || (obUsedCarsInfo[0].State.ToString() == "SD "))
           {
               state = "South Dakota";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "TN") || (obUsedCarsInfo[0].State.ToString() == "TN "))
           {
               state = "Tennessee";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "UT") || (obUsedCarsInfo[0].State.ToString() == "UT "))
           {
               state = "Utah";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "VT") || (obUsedCarsInfo[0].State.ToString() == "VT "))
           {
               state = "Vermont";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "VI") || (obUsedCarsInfo[0].State.ToString() == "VI "))
           {
               state = "US Virgin Islands";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "VA") || (obUsedCarsInfo[0].State.ToString() == "VA "))
           {
               state = "Virginia";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "WA") || (obUsedCarsInfo[0].State.ToString() == "WA "))
           {
               state = "Washington";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "WV") || (obUsedCarsInfo[0].State.ToString() == "WV "))
           {
               state = "West Virginia";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "WI") || (obUsedCarsInfo[0].State.ToString() == "WI "))
           {
               state = "Wisconsin";
           }
           
           else if ((obUsedCarsInfo[0].State.ToString() == "WY") || (obUsedCarsInfo[0].State.ToString() == "WY "))
           {
               state = "Wyoming";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "MD") || (obUsedCarsInfo[0].State.ToString() == "MD "))
           {
               state = "Maryland";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "MA") || (obUsedCarsInfo[0].State.ToString() == "MA "))
           {
               state = "Massachusetts";
           }
           else if ((obUsedCarsInfo[0].State.ToString() == "ID") || (obUsedCarsInfo[0].State.ToString() == "ID "))
           {
               state = "Idaho";
           }
           
           return state;

       }

    }
}
