using Microsoft.EntityFrameworkCore;
using Proletarians.Data;
using Proletarians.Data.Models;
using Prometheus.Proletarians.WpfCore.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prometheus.Proletarians.WpfCore
{
    public class InvationProfilesVm : BaseVm
    {
        public ICommand Save { get; set; }
        public ObservableCollection<InvitationProfile> InvationProfiles { get; set; }
        public InvationProfilesVm()
        {
            using (var context = new PrometheusContext())
            {
                InvationProfiles = new ObservableCollection<InvitationProfile>(context.InvitationProfiles.Include(p => p.Person).ThenInclude(p => p.AgeCategory).Include(p => p).ToList());
            }
            Save = new OnSave(InvationProfiles);
        }
        public class OnSave : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private readonly IEnumerable<InvitationProfile> _invationProfiles;
            public OnSave(IEnumerable<InvitationProfile> invationProfiles)
            {
                _invationProfiles = invationProfiles;
            }
            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter)
            {
                using (var context = new PrometheusContext())
                {
                    context.InvitationProfiles.UpdateRange(_invationProfiles);
                }
            }
        }
    }

    
}
