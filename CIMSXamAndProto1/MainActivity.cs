using Android.App;
using Android.Widget;
using Android.OS;
using CoursesLibrary;

namespace CIMSXamAndProto1
{
    [Activity(Label = "CIMSProto1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button buttonPrev;
        Button buttonNext;
        TextView textTitle;

        ImageView imageCourse;
        TextView textDescription;

        CourseManager courseManager;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            imageCourse = FindViewById<ImageView>(Resource.Id.imageShow);
            textDescription = FindViewById<TextView>(Resource.Id.textDescription);

            buttonPrev.Click += ButtonPrev_Click; 
            buttonNext.Click += ButtonNext_Click;

            courseManager = new CourseManager();
            courseManager.MoveFirst();
            UpdateUI();
            
        }

        private void ButtonPrev_Click(object sender, System.EventArgs e)
        {
            courseManager.MovePrev();
            UpdateUI();
        }

        private void ButtonNext_Click(object sender, System.EventArgs e)
        {
            courseManager.MoveNext();
            UpdateUI();
        }

        private void UpdateUI()
        {
            textTitle.Text = courseManager.Current.Title;
            textDescription.Text = courseManager.Current.Description;
            imageCourse.SetImageResource(ResourceHelper.TranslateDrawableWithReflection(courseManager.Current.Image));
            buttonNext.Enabled = courseManager.CanMoveNext;
            buttonPrev.Enabled = courseManager.CanMovePrev;
        }
    }
}

